using System;
using System.Collections.Generic;

namespace MeetingScheduler
{
    class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string emailId { get; set; }
        public User(int id, string name, string emailId)
        {
            this.id = id;
            this.name = name;
            this.emailId = emailId;
        }
    }
    class MeetingRoom
    {
        public int id { get; set; }
        public string name { get; set; }

        public MeetingRoom(int roomId, string roomName)
        {
            this.id = roomId;
            this.name = roomName;
        }
    }
    class Meeting
    {
        public int id { get; set; }
        public MeetingRoom meetingRoom { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public string subject { get; set; }
        public User organiserId { get; set; }
        public User[] attendeeId { get; set; }

    }

    class MeetingScheduler
    {
        HashSet<Meeting> scheduledMeetings = new HashSet<Meeting>();
        public bool ScheduleMeeting(Meeting meeting)
        {
            bool isValidForRoomTime = IsValid(meeting.start, meeting.end, meeting.meetingRoom.id);
            if(!isValidForRoomTime)
                return false;
            
            return scheduledMeetings.Add(meeting);
        }

        public bool IsValid(int start, int end, int roomId)
        {
            foreach (Meeting meeting in scheduledMeetings)
            {
                if(start >= meeting.start && start < meeting.end)
                    return false;

            }
            return true;
        }
    }

    class Notification
    {
        public bool SendMail(string emailId, string message, Meeting meeting)
        {
            return true;
        }
    }

    class TestClass
    {
        public void TestMeetingScheduler()
        {
            List<User> users = new List<User>();
            for (int i = 1; i <= 5; i++)
            {
                User user = new User(i, "User"+i, "User"+i+"@gmail.com");
                users.Add(user);
            }
            List<MeetingRoom> meetingRooms = new List<MeetingRoom>();
            for (int i = 1; i <= 2; i ++)
            {
                MeetingRoom meetingRoom = new MeetingRoom(i, "MeetingRoom "+i);
                meetingRooms.Add(meetingRoom);
            }

            // Create Meeting Logic
            User[] attendee = new User[] { users[1], users[2] };
            Meeting meeting = new Meeting()
            {
                id = 1,
                meetingRoom = meetingRooms[0],
                start = 9,
                end = 10,
                subject = "Test 1",
                organiserId = users[0],
                attendeeId = attendee
            };
            MeetingScheduler meetingScheduler = new MeetingScheduler();
            meetingScheduler.ScheduleMeeting(meeting);
        }
    }
}