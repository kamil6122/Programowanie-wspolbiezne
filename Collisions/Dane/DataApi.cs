using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class AbstractDataApi
    {
        public abstract void CreateField(int width, int height, int amountOfBalls);
        public abstract List<Ball> GetBalls();
        public abstract void StopUpdating();
        public abstract bool IsUpdating();
        public abstract Field Field { get; }
        public static AbstractDataApi Api()
        {
            return new DataApi();
        }
        internal class DataApi : AbstractDataApi
        {
            private Field field;
            private bool updating;
            private readonly object locked = new object();

            public bool Updating
            {
                get { return updating; }
                set { updating = value; }
            }

            public override Field Field
            {
                get { return field; }
            }

            public override void CreateField(int width, int height, int amountOfBalls)
            {
                this.field = new Field(width, height, amountOfBalls);
                this.Updating = true;
                List<Ball> balls = GetBalls();

                foreach (Ball ball in balls)
                {
                   
                    Thread thread = new Thread(() =>
                    {
                        while (updating)
                        {
                            lock (locked)
                            {
                                ball.changePosition(ball.X + ball.XDirection, ball.Y + ball.YDirection);
                            }
                            Thread.Sleep(5);
                        }
                    });
                    thread.Start();
                }
            }

            public override void StopUpdating() 
            {
                this.Updating = false;
            }

            public override bool IsUpdating()
            {
                return this.Updating;
            }

            public override List<Ball> GetBalls()
            {
                return this.field.Balls;
            }

        }
    }
}
