using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreFx.Tests._NonClass
{
    public class Events
    {
        public event VoidVoid Event;

        [Fact]
        public void EventAttachAndDetachTest()
        {
            Assert.Null(Event);
            Event -= Events_Event;
            Assert.Null(Event);
        }

        private void Events_Event()
        {
            
        }
    }
}
