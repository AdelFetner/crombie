using Crombievents.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Crombievents.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("events-with-most-attendees")]
        public ActionResult<List<object>> GetEventsWithMostAttendees()
        {
            try
            {
                var result = _reportService.GetEventsWithMostAttendees();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("total-income-by-event/{eventId}")]
        public ActionResult<object> GetTotalIncomeByEvent(int eventId)
        {
            try
            {
                var result = _reportService.GetTotalIncomeByEvent(eventId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("events-by-organizer/{organizerId}")]
        public ActionResult<List<object>> GetEventsByOrganizer(int organizerId)
        {
            try
            {
                var result = _reportService.GetEventsByOrganizer(organizerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("users-with-most-reservations")]
        public ActionResult<List<object>> GetUsersWithMostReservations()
        {
            try
            {
                var result = _reportService.GetUsersWithMostReservations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("upcoming-events-by-location/{location}")]
        public ActionResult<List<object>> GetUpcomingEventsByLocation(string location)
        {
            try
            {
                var result = _reportService.GetUpcomingEventsByLocation(location);
                if(result == null)
                {
                    new Exception("An error ocuyrred during search");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("payments-report-by-month/{month}/{year}")]
        public ActionResult<List<object>> GetPaymentsReportByMonth(int month, int year)
        {
            try
            {
                var result = _reportService.GetPaymentsReportByMonth(month, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("event-and-reservation-history-by-user/{userId}")]
        public ActionResult<List<object>> GetEventAndReservationHistoryByUser(int userId)
        {
            try
            {
                var result = _reportService.GetEventAndReservationHistoryByUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("employees-with-most-sales")]
        public ActionResult<List<object>> GetEmployeesWithMostSales()
        {
            try
            {
                var result = _reportService.GetEmployeesWithMostSales();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}