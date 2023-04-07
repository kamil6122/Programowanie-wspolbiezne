using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logika;

namespace Model
{
    public abstract class AbstractModelApi
    {
        public static AbstractModelApi Api(AbstractLogicApi abstractLogicApi = null)
        {
            return new ModelApi();
        }

        public abstract void StartUpdating(int amountOfBalls);
        public abstract void StopUpdating();
        public abstract bool IsUpdating();
        public abstract ObservableCollection<Ball> GetBalls();


        public class ModelApi : AbstractModelApi
        {
            private ObservableCollection<Ball> balls = new ObservableCollection<Ball>();
            private AbstractLogicApi logicApi = AbstractLogicApi.Api(null);

            public ModelApi(AbstractLogicApi abstractLogicApi = null)
            {
                if (abstractLogicApi == null)
                {
                    this.logicApi = AbstractLogicApi.Api();
                }
                else
                {
                    this.logicApi = abstractLogicApi;
                }
            }

            public ObservableCollection<Ball> Balls
            { 
                get { return balls; } 
                set { balls = value; }
            }

            public override void StartUpdating(int amountOfBalls)
            {
                logicApi.StartUpdating(500, 300, amountOfBalls);
            }

            public override void StopUpdating()
            {
                logicApi.StopUpdating();
            }

            public override bool IsUpdating() 
            {
                return logicApi.IsUpdating();
            }

            public override ObservableCollection<Ball> GetBalls()
            {
                List<BallLogic> logicBalls = logicApi.GetBalls();
                Balls.Clear();
                foreach (BallLogic ball in logicBalls)
                {
                    Balls.Add(new Ball(ball));
                }
                return Balls;
            }

        }
    }
}
