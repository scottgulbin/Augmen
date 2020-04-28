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
    class ExerciseInstance
    {
        public int ExerciseAppID
        {
            get
            {
                return ExerciseAppID;
            }
        }
        public double RestTime { get; set; }
        public double Weight { get; set; }
        public string TypeOfLift { get; set; }
        public Exercise BaseExercise { get; set; }


        public ExerciseInstance(Exercise exercise, double resttime, double weight, string typeoflift)
        {
            this.RestTime = resttime;
            this.Weight = weight;
            this.TypeOfLift = typeoflift;
            this.BaseExercise = exercise;
        }
    }
}