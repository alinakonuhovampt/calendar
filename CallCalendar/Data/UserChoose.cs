using System;
using System.Collections.Generic;

namespace CallCalendar
{
    public class UserChoose
    {
        public readonly static string[] options =
        {
            "mom", "dad", "grandma", "grandpa", "brother", "sister", "child", "friend_female", "friend_male"
        };

        public UserChoose(DateOnly date)
        {
            this.date = date;
        }

        public DateOnly date { get; init; }
        public List<string> items = new ();
    }
}