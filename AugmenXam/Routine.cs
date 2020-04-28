using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Augmen
{
    class Routine
    {
        public int WRID { get; set; }
        public List<Workout> workouts { get; set; }

        public Routine()
        {
            workouts = new List<Workout>();
        }

        public void AddWorkout(Workout workout)
        {
            workouts.Add(workout);
        }

        public Workout FindWorkout(string name)
        {
            foreach (var workout in workouts)
            {
                if (workout.Name == name)
                {
                    return workout;
                }
            }
            return null;
        }

        public void AllWorkouts()
        {
            foreach (var workout in workouts)
            {
                Console.WriteLine(workout.Name);
            }
        }
    }
}