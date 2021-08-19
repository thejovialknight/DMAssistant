using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.Input
{
    public class InputSystem : EntityGraph
    {
        List<InputAcceptor> inputAcceptors = new List<InputAcceptor>();

        public override void OnInitialize()
        {
            game.onEntityCreated += TryRegisterInputtable;
            game.onEntityDestroyed += TryRemoveInputtable;
        }

        public void TryRegisterInputtable(Entity entity, EntityGraph graph)
        {
            InputAcceptor inputAcceptor = entity.Component<InputAcceptor>();
            if (inputAcceptor != null)
            {
                inputAcceptors.Add(inputAcceptor);
            }
        }

        public void TryRemoveInputtable(Entity entity, EntityGraph graph)
        {
            InputAcceptor inputAcceptor = entity.Component<InputAcceptor>();
            if (inputAcceptor != null && inputAcceptors.Contains(inputAcceptor))
            {
                inputAcceptors.Remove(inputAcceptor);
            }
        }

        public override void OnTick(double deltaTime)
        {
            if (Console.KeyAvailable == true) {
                foreach (InputAcceptor inputAcceptor in inputAcceptors)
                {
                    inputAcceptor.RaiseOnKey(Console.ReadKey(true));
                }
            }
        }
    }
}
