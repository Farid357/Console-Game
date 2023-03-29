﻿using System.Diagnostics;

namespace BananaParty.BehaviorTree
{
    public class TraceInfoNode : BehaviorNode
    {
        private readonly string _message;

        public TraceInfoNode(string message)
        {
            _message = message;
        }

        public override BehaviorNodeStatus OnExecute(float deltaTime)
        {
            Trace.TraceInformation(_message);

            return BehaviorNodeStatus.Success;
        }
    }
}
