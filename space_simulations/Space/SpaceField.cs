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

            for (int i = 0; i < spaceObjects.Length; i++) {
                
                for (int j = 0; j < spaceObjects.Length; j++){
                    if (i == j)
                        continue;

                    float Distanse = FindingDistancePoints(spaceObjects[i].GetPos(), spaceObjects[j].GetPos());
                    float MassaI = spaceObjects[i].GetMas();
                    float MassaJ = spaceObjects[j].GetMas();

                    if (CrashCheck(spaceObjects[i], spaceObjects[j])) {
                        if (MassaI > MassaJ) {
                            spaceObjects[i].AddetMass(spaceObjects[j].GetMas());
                            spaceObjects[i].AddetRad(spaceObjects[j].GetRad());
                            removePlanets(j);
                        }else {
                            spaceObjects[j].AddetMass(spaceObjects[i].GetMas());
                            spaceObjects[j].AddetRad(spaceObjects[i].GetRad());
                            removePlanets(i);
                        }
                    }
                    else {
                        Distanse *= 10.4F;
                        float Forse = (float)((MassaI * MassaJ) / Math.Pow(Distanse, 3));

                        Vector2f Diss = GetDiff(spaceObjects[i].GetPos(), spaceObjects[j].GetPos());
                        Diss.X *= Forse * MassaJ;
                        Diss.Y *= Forse * MassaJ;

                        spaceObjects[i].AddetVel(Diss);
                    }
                }
            }

            for (int i = 0; i < spaceObjects.Length; i++){
                spaceObjects[i].MoveObjectAccordingToVelocity();
            }

        }

       

        private bool CrashCheck(SpaceObject pos1, SpaceObject pos2) {
            float distanse = FindingDistancePoints(pos1.GetPos(), pos2.GetPos());
            float OverallRadius = pos1.GetRad() + pos2.GetRad();

            if ((distanse - OverallRadius) < 0) {
                return true;
            }
            return false;
        }

        private Vector2f GetDiff(Vector2f pos1, Vector2f pos2)
        {
            return new Vector2f(pos2.X - pos1.X, pos2.Y - pos1.Y);
        }


        public SpaceObject GetPlanets(int index){
            return spaceObjects[index];
        }

        public int GetNumPlanets(){
            return spaceObjects.Length;
        }


        public void addPlanets(SpaceObject newPlanets) {
            ArrayEditor.addObject(ref spaceObjects , newPlanets, 0);
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
