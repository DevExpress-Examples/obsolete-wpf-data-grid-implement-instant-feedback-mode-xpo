using System;
using DevExpress.Xpo;

namespace InstantFeedbackMode {
    public class TestObject : XPObject {
        string _subject;
        public string Subject {
            get { return _subject; }
            set { SetPropertyValue<string>("Subject", ref _subject, value); }
        }
        DateTime _sent;
        public DateTime Sent {
            get { return _sent; }
            set { SetPropertyValue<DateTime>("Sent", ref _sent, value); }
        }

        bool _hasAttachment;
        public bool HasAttachment {
            get { return _hasAttachment; }
            set { SetPropertyValue<bool>("HasAttachment", ref _hasAttachment, value); }
        }
        public TestObject(Session session) : base(session) { }
        public TestObject() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}

