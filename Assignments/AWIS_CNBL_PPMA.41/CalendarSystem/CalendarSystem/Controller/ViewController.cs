﻿using System;
using CalendarSystem.Model;
using CalendarSystem.View;

namespace CalendarSystem.Controller
{
    /// <summary>
    /// The view controller handles all calls and creations of the view. It implements the IObserver interface and therefore can get notified when changes in the model happens.
    /// </summary>
    class ViewController
    {
        private static ViewController _instance = null;

        private CalendarView _calendarView;
        private EventView _eventView;
        private NotificationView _notificationView;
        private MainView _mainView;

        private ViewController()
        {
        }

        /// <summary>
        /// Create the main view
        /// </summary>
        public void startMainView()
        {
            new MainView(_calendarView);
        }

        /// <summary>
        /// Update the calendar (a change in the model has probably happened)
        /// </summary>
        private void updateCalendarView()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new event view
        /// </summary>
        public void createEventView()
        {
            throw new NotImplementedException();
        }

        public void createNotificationView(int ID, Notification notification)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create an Event view with the data from a already existing event (update event)
        /// </summary>
        /// <param name="iEvent"></param>
        public void createEventView(IEvent iEvent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Change the overviewtype of the calendarview.
        /// Right now it does not use the enum type correctly.
        /// Must be updated to properly use the enum type.
        /// </summary>
        /// <param name="overviewType"></param>
        public void UpdateCalenderOverview(string overviewType)
        {
            CalendarView.OverviewType newOverviewType;
            // convert string to overviewtype
            switch (overviewType.ToLower())
            {
                case "daily":
                    newOverviewType = CalendarView.OverviewType.daily;
                    break;
                case "weekly":
                    newOverviewType = CalendarView.OverviewType.weekly;
                    break;
                case "montly":
                    newOverviewType = CalendarView.OverviewType.montly;
                    break;
                default:
                    throw new Exception();
            }
            _calendarView.changeOverviewType(newOverviewType);
        }

        /// <summary>
        /// Singleton pattern. Makes sure only one instance can exist at a given time, and give classes easy access to the controller.
        /// </summary>
        /// <returns>The only instance of the class</returns>
        public static ViewController getInstance()
        {
            if (_instance == null) _instance = new ViewController();
            return _instance;
        }
    }
}
