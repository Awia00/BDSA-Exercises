﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    interface IAbstractStorage : IObservable
    {
        void loginAuthentication(string userName, string password);

        /// <summary>
        /// Save an event to the storage
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <param name="notification"></param>
        void SaveEvent(string description, DateTime dateTime, TimeSpan timeSpan, Notification notification);
        /// <summary>
        /// Update an event to the storage
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <param name="notification"></param>
        void UpdateEvent(int ID, string description, DateTime dateTime, TimeSpan timeSpan, Notification notification);
        /// <summary>
        /// Returns all events in the active calendar
        /// </summary>
        /// <returns></returns>
        IList<IEvent> GetAllEvents();
        /// <summary>
        /// Get a single event with a given ID if possible.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IEvent GetEvent(int ID);
        /// <summary>
        /// Return all events between to given dates.
        /// </summary>
        /// <param name="beginDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime);
        /// <summary>
        /// Create a tag and save it in the storage.
        /// </summary>
        /// <param name="tag"></param>
        void CreateTag(Tag tag);
    }
}