using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;


namespace TomorrowsLunch.Repositories
{
    public class CalendarRepository : BaseRepository<Calendar>
    {
        //public Calendar CreateCalendar(Calendar calendar)
        //{
        //    try
        //    {
        //        using (var context = new ApplicationDbContext())
        //        {
        //            context.Calendars.Add(calendar);
        //            context.SaveChanges();
        //        }
        //        return calendar;
        //    }
        //    catch (Exception ex)
        //    {
        //        return calendar;
        //    }
        //}
        public List<Calendar> GetAll(Guid currentUser)
        {
            IQueryable<Calendar> calendars;
            var calendarsList = new List<Calendar>();
            using (var db = new ApplicationDbContext())
            {
                calendars = db.Calendars.Include(c => c.Meal).Where(c => !c.Deleted).Where(c => c.CreatedByUser == currentUser).OrderByDescending(x => x.DateCreated);
                calendarsList = calendars.ToList();
            }
            return calendarsList;
        }
        public List<Calendar> GetLastTwo(Guid currentUser)
        {
            IQueryable<Calendar> calendars;
            var calendarsList = new List<Calendar>();
            using (var db = new ApplicationDbContext())
            {
                calendars = db.Calendars.Include(c => c.Meal).Where(c => !c.Deleted).Where(c => c.CreatedByUser == currentUser).OrderByDescending(x => x.DateCreated);
                calendarsList = calendars.ToList();
                if (calendarsList.Count > 2)
                {
                    return calendarsList.Take(2).ToList();
                }
                else
                {
                    return calendarsList;
                }
            }
        }
        public Calendar GetSpecific(Guid specificCalendarId)
        {
            Calendar returnValue;
            IQueryable<Calendar> calendar;
            using (var db = new ApplicationDbContext())
            {
                //include
                calendar = db.Calendars.Include(c => c.Meal).Where(c => c.Id == specificCalendarId);
                returnValue = calendar.FirstOrDefault();
            }
            return returnValue;
        }
    }
}