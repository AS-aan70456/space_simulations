using System;
using System.Threading;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using space_simulations.Space;

namespace space_simulations{
    class Program{
        static void Main(string[] args){
            new myProgram().Start();
        }
    }

    class myProgram {

        const uint ScrenWidth = 1080;
        const uint ScrenHeight = 720;
        RenderWindow window = new RenderWindow(new VideoMode(ScrenWidth, ScrenHeight), "Spece_sumulator", Styles.Fullscreen);

        SpaceField space;
        Random rand;

        public void Start(){
            space = new SpaceField();

            space.addPlanets(new SpaceObject(new Vector2f(1000, 290), new Vector2f(-6, 0), 6, 6, Color.Blue));
            space.addPlanets(new SpaceObject(new Vector2f(1000, 354), new Vector2f(6, 0), 4.5f, 4.5f, Color.Green));
            space.addPlanets(new SpaceObject(new Vector2f(1000, 520), new Vector2f(0, 0), 18, 1100, Color.Yellow));
            space.addPlanets(new SpaceObject(new Vector2f(1000, 620), new Vector2f(-5.9f, 0), 3.5f, 3.5f, Color.Blue));

            space.addPlanets(new SpaceObject(new Vector2f(800, 530), new Vector2f(3.2f, 1.4f), 1.7f, 1.7f, Color.White));

            //VertexArray vertex = new VertexArray(PrimitiveType.LineStrip);

            while (true) {
                window.Clear();
                space.Update();

                Thread.Sleep(15);

                for (int i = 0; i < space.GetNumPlanets(); i++) {
                    SpaceObject BufferPlanets = space.GetPlanets(i);
                    Vector2f _position = BufferPlanets.GetPos();
                    Vector2f _velosity = BufferPlanets.GetVel();
                    float _radius = BufferPlanets.GetRad();

                    CircleShape Shape = new CircleShape(_radius);
                    Shape.Position = new Vector2f(_position.X - _radius, _position.Y - _radius);
                    Shape.FillColor = BufferPlanets.GetColor();

                    window.Draw(Shape);
                }

                window.Display();
                window.DispatchEvents();
            }
        }
    }
}
