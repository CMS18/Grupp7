﻿using System;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel
{
    public class Exit
    {
        public Room LeadsTo { get; }
        public int ExitId { get; }
        public bool Locked { get; set; }
        public bool EndPoint { get; }
        public string ExitName { get; }
        public string OpenExit { get; }
        public string LockedString { get; }
        public string Examine { get; set; }


        public Exit(Room leadsto, int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine)
        {
            LeadsTo = leadsto;
            ExitId = exitId;
            Locked = locked;
            EndPoint = endPoint;
            ExitName = name;
            OpenExit = openExit;
            LockedString = lockedString;
            Examine = examine;
        }

        public void ExamineExit() => Console.WriteLine(Examine);

        public virtual void Unlock() => Locked = false;

        public virtual void LockedDescription() => Console.WriteLine(LockedString);

        public virtual bool Unlock(Player player)
        {
            return false;
        }


    }
}