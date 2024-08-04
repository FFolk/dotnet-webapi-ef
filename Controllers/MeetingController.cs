using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using dotnet_webapi_ef.DTOs.MeetingDTO;
using dotnet_webapi_ef.Mapper;
using dotnet_webapi_ef.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private ApplicationDBContext _context;
        public MeetingController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMeetingAll()
        {
            var meeting = _context.Meetings.Select(m => m.ToMeetingDTO());
            return Ok(meeting);
        }

         [HttpGet("{id}")]
        public IActionResult GetMeetingByID([FromRoute] int id)
        {
            var meeting = _context.Meetings.Find(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return Ok(meeting.ToMeetingDTO());
        }

        [HttpPost]
        public IActionResult InsertMeeting([FromBody] MeetingDTO meetingDTO)
        {
            Meeting meeting = meetingDTO.ToMeeting();
            _context.Meetings.Add(meeting);
            int affect = _context.SaveChanges();
            if (affect > 0)
            {
                return CreatedAtAction(nameof(GetMeetingByID), new{id = meeting.Idx},meeting.ToMeetingDTO());
            }
            return StatusCode(400);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteMeeting([FromRoute] int id){
            Meeting meeting = _context.Meetings.Find(id);
            if (meeting != null){
                _context.Meetings.Remove(meeting);
                int affect = _context.SaveChanges();
                if(affect > 0){
                    return Ok();
                }
            }
            return StatusCode(400);
        }

        [HttpPut("put/{id}")]
        public IActionResult PutMeeting([FromRoute] int id, [FromBody] MeetingDTO meetingDTO){
            Meeting meeting = _context.Meetings.Find(id);
            if(meeting != null){

                meeting.Detail = meetingDTO.Detail;
                meeting.Meetingdatetime = meetingDTO.Meetingdatetime;
                meeting.Latitude = meetingDTO.Latitude;
                meeting.Longitude = meetingDTO.Longitude;

                 _context.Meetings.Update(meeting);
                int affect = _context.SaveChanges();
                if(affect > 0){
                    return Ok();
                }
            }
            return StatusCode(400);
        }
    }
}