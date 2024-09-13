using SQLite;
using System.Diagnostics;

namespace FitnessTracker
{
    public static class Database
    {
        private static SQLiteConnection database;
        public static void createDatabase()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFile);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<StepHistory>();
        }
        public static void addStepHistory(int steps, DateTime date)
        {
            //get last entry, check if steps are higher than last entry, if so , update, else, add new entry
            var lastEntry = database.Table<StepHistory>().OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastEntry != null)
            {
                if (lastEntry.Steps <= steps && lastEntry.Date.Date == date.Date)
                {
                    lastEntry.Steps = steps;
                    database.Update(lastEntry);
                    return;
                }


            }

            database.Insert(new StepHistory { Steps = steps, Date = date });

        }
        public static int getDaySteps(DateTime date)
        {
            //gets entries with the same day and sums up the steps
            int totalSteps = 0;
            var steps = database.Table<StepHistory>();
            if (steps == null)
            {
                return 0;
            }
            //wasnt able to compare dates using linq :(
            foreach (var step in steps)
            {
                if (step.Date.Date == date.Date)
                {
                    totalSteps += step.Steps;
                }
            }
            Debug.WriteLine("Steps: " + steps);
            return totalSteps;

        }
        public class StepHistory
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public int Steps { get; set; }
            public DateTime Date { get; set; }
        }

    }
}