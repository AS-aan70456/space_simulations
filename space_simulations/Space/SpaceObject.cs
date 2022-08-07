using System;
using SFML.System;

namespace space_simulations.Space{

    class SpaceObject{

        private Vector2f Position;
        private Vector2f Velocity;
        private float Radius;
        private float Mass;


        public SpaceObject(Vector2f _pos, Vector2f _vel, float _rot, float _mas) {

            Position = _pos;
            Velocity = _vel;
            Radius = _rot;
            Mass = _mas;

        }

        public void MoveObjectAccordingToVelocity() {
            Position += (Velocity * 0.07f);
        }

        public Vector2f GetPos() {
            return Position;
        }
        public Vector2f GetVel(){
            return Velocity;
        }

        public float GetRad(){
            return Radius;
        }

        public float GetMas(){
            return Mass;
        }

        public void SetPos(Vector2f _pos){
            Position = _pos;
        }
        public void SetVel(Vector2f _vel){
            Velocity = _vel;
        }

        public void SetRad(float _rot){
            Radius = _rot;
        }

        public void SetMas(float _mas){
            Mass = _mas;
        }

        public void AddetPos(Vector2f _pos){
            Position += _pos;
        }

        public void AddetVel(Vector2f _vel){
            Velocity += _vel;
        }

    }
}

