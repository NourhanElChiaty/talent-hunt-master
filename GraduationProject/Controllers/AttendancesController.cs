using GraduationProject.DTOs;
using GraduationProject.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GraduationProject.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();



            if (_context.Attendance.Any(a => a.AttendeeId == userId && a.EventId == dto.EventId))
                return BadRequest("The attendance already exists");

            var Attendance = new Attendance
            {
                EventId = dto.EventId,
                AttendeeId = userId
            };
            _context.Attendance.Add(Attendance);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _context.Attendance.SingleOrDefault(a => a.AttendeeId == userId && a.EventId == id);
            if (attendance == null)
                return NotFound();

            _context.Attendance.Remove(attendance);
            _context.SaveChanges();
            return Ok(id);
        }
    }
}

