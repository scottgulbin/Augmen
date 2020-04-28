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
    class Exercise
    {
        public string Name { get; set; }
        public int ExerciseID { get; }
        public string Type { get; set; }
        public string BodyPart { get; set; }

        public Exercise()
        {

        }

        public Exercise(Exercise exercise)
        {
            this.Name = exercise.Name;
        }

        public Exercise(string Name, string Type, string BodyPart)
        {
            this.Name = Name;
            this.Type = Type;
            this.BodyPart = BodyPart;
        }
    }
}