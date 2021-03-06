﻿using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHelper.Api.Models.Messanging;
using MyHelper.Api.Models.Request;
using MyHelper.Api.Models.Response;
using MyHelper.Api.Services.Notes;
using MyHelper.Api.Services.Token;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHelper.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/notes")]
    public class NotesController : BaseController
    {
        private readonly INoteService _noteService;
        private readonly IRequestClient<IFeedMessage> _requestClient;

        public NotesController(
            INoteService noteService,
            ITokenService tokenService,
            IRequestClient<IFeedMessage> requestClient) : base(tokenService)
        {
            _noteService = noteService;
            _requestClient = requestClient;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServerResponse<List<NoteResponse>>), 200)]
        public async Task<ServerResponse<List<NoteResponse>>> GetNotesAsync(NoteFilterRequest noteFilterRequest)
        {
            return AOResultToServerResponse(await _noteService.GetNotesAsync(AccountId, noteFilterRequest));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServerResponse<NoteResponse>), 200)]
        public async Task<ServerResponse<NoteResponse>> GetNoteAsync(long id)
        {
            return AOResultToServerResponse(await _noteService.GetNoteAsync(AccountId, id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServerResponse<long>), 200)]
        public async Task<ServerResponse<long>> CreateNoteAsync([FromBody] NoteRequest noteRequest)
        {
            return AOResultToServerResponse(await _noteService.CreateNoteAsync(noteRequest).ContinueWith(x =>
            {
                var request = _requestClient.Create(_noteService.CreateNoteFeedMessage(noteRequest, x.Result.Result));

                request.GetResponse<FeedMessage>();

                return x.Result;
            }));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServerResponse), 200)]
        public async Task<ServerResponse> UpdateNoteAsync([FromBody] NoteRequest noteRequest)
        {
            return AOResultToServerResponse(await _noteService.UpdateNoteAsync(noteRequest));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ServerResponse), 200)]
        public async Task<ServerResponse> DeleteNotekAsync(long id)
        {
            return AOResultToServerResponse(await _noteService.DeleteNoteAsync(id));
        }
    }
}