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
        RenderWindow window = new RenderWindow(new VideoMode(ScrenWidth, ScrenHeight), "Spece_sumulator");

        SpaceField space;
        Random rand;

        public void Start(){
            space = new SpaceField();
            


            space.addPlanets(new SpaceObject(new Vector2f(400, 400), new Vector2f(0.5f, 0), 10, 1000));
            space.addPlanets(new SpaceObject(new Vector2f(500, 500), new Vector2f(-0.5f, 0), 10, 1000));

            while (true) {
                window.Clear(Color.White);
                space.Update();

                for (int i = 0; i < space.GetNumPlanets(); i++) {
                    SpaceObject BufferPlanets = space.GetPlanets(i);
                    Vector2f _position = BufferPlanets.GetPos();
                    Vector2f _velosity = BufferPlanets.GetVel();
                    float _radius = BufferPlanets.GetRad();

                    CircleShape Shape = new CircleShape(_radius);
                    Shape.Position = new Vector2f(_position.X - _radius, _position.Y - _radius);
                    Shape.FillColor = Color.Black;

                    VertexArray vertex = new VertexArray(PrimitiveType.Lines);
                    vertex.Append(new Vertex(BufferPlanets.GetPos(), Color.Black));
                    vertex.Append(new Vertex(BufferPlanets.GetPos() + (BufferPlanets.GetVel() * _radius), Color.Black));


                    window.Draw(vertex);
                    window.Draw(Shape);
                }

                window.Display();
                window.DispatchEvents();
            }
        }
    }
}
