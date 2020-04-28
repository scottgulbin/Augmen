using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;

namespace AugmentPhoneApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button workout1B = FindViewById<Button>(Resource.Id.Workout1);
            Button workout2B = FindViewById<Button>(Resource.Id.Workout2);
            TextView workoutText = FindViewById<TextView>(Resource.Id.textView2);

            var squat = new Exercise("Squat", "Barbell", "Legs");
            var bench = new Exercise("Bench Press", "Dumbbell", "Chest");
            var pushup = new Exercise("Push Up", "Bodyweight", "Chest");
            var deadlift = new Exercise("Deadlift", "Barbell", "Legs");

            var ei1 = new ExerciseInstance(squat, 1.30, 225, "Primary");
            var ei2 = new ExerciseInstance(bench, 1.45, 135, "Secondary");
            var ei3 = new ExerciseInstance(pushup, 1.00, 0, "Tertiary");


            var workout = new Workout("Workout1")
            {
                ListOfExercises = new List<ExerciseInstance>
                {
                    ei1,
                    ei2,
                    ei3
                }
            };

            var workout2 = new Workout("Workout2");
            workout2.AddExercise(ei2);
            workout2.AddExercise(ei1);
            var curWorkout = workout.ListOfExercises;
            var listofworkouts = new Routine();
            listofworkouts.AddWorkout(workout);
            listofworkouts.AddWorkout(workout2);

            var ei4 = new ExerciseInstance(deadlift, 5.00, 300, "Tertiary");
            string workoutname = "";
            workout1B.Click += (sender, e) =>
            {
                workoutname = "Workout1";
                listofworkouts.FindWorkout(workoutname).AddExercise(ei4);
                ReadWorkouts(listofworkouts, workoutText);
            };
            workout2B.Click += (sender, e) =>
            {
                workoutname = "Workout2";
                listofworkouts.FindWorkout(workoutname).AddExercise(ei4);
                ReadWorkouts(listofworkouts, workoutText);
            };




        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void ReadWorkouts(Routine workouts, TextView workoutText)
        {
            var result = "";
            foreach (var workout in workouts.workouts)
            {
                result += $"Your {workout.Name} contains the following: \n";
                foreach (var exercise in workout.ListOfExercises)
                {
                    result += $"{exercise.BaseExercise.Type} {exercise.BaseExercise.Name} at {exercise.Weight}lbs as your {exercise.TypeOfLift} lift that targets your {exercise.BaseExercise.BodyPart}\n";
                }
                result += ("\n\n");
            }
            workoutText.Text = result;
        }
    }
}