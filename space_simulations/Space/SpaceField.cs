using System;
using SFML.System;

namespace space_simulations.Space{

    class SpaceField{

        SpaceObject[] spaceObjects = new SpaceObject[0];


        public SpaceField() {
        
        }

        float FindingDistancePoints(Vector2f pos1, Vector2f pos2) {
            float a = pos1.Y - pos2.Y;
            float b = pos1.X - pos2.X;
            float c = MathF.Sqrt((a * a) + (b * b));
            return c;
        }



    }


}
