using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Disolution.Code {

    /// <summary>
    /// Allows for multiple Inputs to be assigned for any number of players.
    /// </summary>
    public class Input {
        public Keys Up { get; set; }
        public Keys Down { get; set; }
        public Keys Left { get; set; }
        public Keys Right { get; set; }
    }
}
