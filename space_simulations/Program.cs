using System;
using System.Threading;
using SFML.System;
using space_simulations.Space;

namespace space_simulations{
    class Program{
        static void Main(string[] args){
            new myProgram().Start();
        }
    }

    class myProgram {

        SpaceField space;

        public void Start(){
            space = new SpaceField();



        }
    }
}
