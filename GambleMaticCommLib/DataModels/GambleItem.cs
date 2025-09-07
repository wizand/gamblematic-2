using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleMaticCommLib.DataModels
{
    public class GambleItem
    {

        public long Id { get; set; }
        public string GambleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public SportingParticipant[] Participants { get; set; } = Array.Empty<SportingParticipant>();
        public GambleEvent Event { get; set; } = new GambleEvent();
    }

    public class SportingParticipant
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class  GambleEvent
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime EventDate { get; set; } = DateTime.UtcNow;
    }

    public class Gambler
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RealName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
    }

    public class GambleResult
    {
        public long Id { get; set; }
        public long GambleItemId { get; set; }
        public string Result { get; set; } = string.Empty;
    }

    public class  Gamble
    {
        public long Id { get; set; }
        public long GamblerId { get; set; }
        public long GambleItemId { get; set; }
        public long GambleResultId { get; set; }
        public bool IsCompleted { get; set; } = false;

    }
}
