using System;
using System.Collections.Generic;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            GiantKillerRobot robot = new GiantKillerRobot();
            robot.init();

            Target animal, human, superhero;
            animal = new Target(TargetType.Animal);
            human = new Target(TargetType.Human);
            superhero = new Target(TargetType.SuperHero);

            Target[] targets = { animal, human, superhero };

            Earth earth = Planets.earth;
            earth.setEntities(targets);

            robot.setIntensity(Intensity.Kill);
            robot.setTargets(targets);

            while (robot.isActive() && earth.doesContainLife())
            {
                if (robot.getTarget() != null && robot.getTarget().isAlive())
                    robot.FireLaserAt(robot.getTarget());
                else
                    robot.AcquireNextTarget();
            }
        }
    }
    class Planets
    {
        public static Earth earth = new Earth();


    }

    class Earth
    {
        protected List<Target> entities;

        public Earth()
        {
            Console.WriteLine($"Created Planet: Earth");
            this.entities = new List<Target>();
        }

        public void setEntities(Target[] entity)
        {
            this.entities.Clear();
            foreach (Target a in entity)
            {
                this.entities.Add(a);
            }
        }

        public bool doesContainLife()
        {
            foreach (Target target in this.entities)
                if (target.isAlive())
                    return true;
            return false;
        }
    }
    enum Intensity
    {
        Neutral, Kill
    }

    enum TargetType
    {
        Animal, Human, SuperHero
    }

    class GiantKillerRobot
    {

        private bool Active;
        private Target CurrentTarget;
        private List<Target> targets;
        private Intensity EyeLaserIntensity;

        public GiantKillerRobot()
        {
            targets = new List<Target>();
        }

        public void setActive(bool a)
        {
            this.Active = a;
        }

        public bool isActive()
        {
            return this.Active;
        }

        public void setIntensity(Intensity intensity)
        {
            this.EyeLaserIntensity = intensity;
        }

        public Intensity getIntensity()
        {
            return this.EyeLaserIntensity;
        }

        public void setTarget(Target target)
        {
            this.CurrentTarget = target;
        }

        public Target getTarget()
        {
            return this.CurrentTarget;
        }

        public void init()
        {
            this.Active = true;
            this.EyeLaserIntensity = Intensity.Neutral;
        }

        public void setTargets(Target[] targets)
        {
            this.targets.Clear();
            foreach (Target target in targets)
            {
                this.targets.Add(target);
            }
        }

        public void AcquireNextTarget()
        {
            foreach (Target target in this.targets)
            {
                if (target.isAlive())
                {
                    this.CurrentTarget = target;
                    Console.WriteLine($"Acquired next target: {target.getType().ToString()}");
                    return;
                }
            }
            this.Active = false;
        }

        public void FireLaserAt(Target target)
        {
            target.setAlive(false);
            Console.WriteLine($"Fired laser at {target.getType().ToString()}");
        }
    }

    class Target
    {
        protected bool Alive;
        protected TargetType type;

        public Target(TargetType type)
        {
            this.Alive = true;
            this.type = type;
            Console.WriteLine($"Created Target Entity: {type.ToString()}");
        }

        public void setAlive(bool a)
        {
            this.Alive = a;
        }

        public bool isAlive()
        {
            return this.Alive;
        }

        public TargetType getType()
        {
            return this.type;
        }
    }
}
