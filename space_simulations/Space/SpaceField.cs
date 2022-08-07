using System;
using space_simulations.Utilities;
using SFML.System;

namespace space_simulations.Space{

    class SpaceField{

        SpaceObject[] spaceObjects;


        public SpaceField() {
            spaceObjects = new SpaceObject[0];
        }

        public void Update() {

            bool Collision = false;
            int countPlanet = spaceObjects.Length;

            for (int i = 0; i < countPlanet; i++) {
                
                for (int j = 0; j < countPlanet && (i != j); j++){
                
                    float ForceGravity = FindingDistancePoints(spaceObjects[i].GetPos(), spaceObjects[j].GetPos());

                
                }
                spaceObjects[i].MoveObjectAccordingToVelocity();
            }

        }

        



        public SpaceObject GetPlanets(int index){
            return spaceObjects[index];
        }

        public int GetNumPlanets(){
            return spaceObjects.Length;
        }


        public void addPlanets(SpaceObject newPlanets, int index) {
            ArrayEditor.addObject(ref spaceObjects , newPlanets, index);
        }

        public void removePlanets(int index){
            ArrayEditor.removeObject(ref spaceObjects, index);
        }

        float FindingDistancePoints(Vector2f pos1, Vector2f pos2) {
            float a = pos1.Y - pos2.Y;
            float b = pos1.X - pos2.X;
            float c = MathF.Sqrt((a * a) + (b * b));
            return c;
        }
    }
}
