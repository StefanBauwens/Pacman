using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class EnemyController
    {
        EnemyModel enemyModel;
        EnemyUI enemyUI;

        public EnemyController(PlayerController player, TileController beginTile) //constructor
        {
            this.enemyModel = new EnemyModel();
            this.enemyUI = new EnemyUI(this);
        }

        public EnemyUI View
        {
            get { return enemyUI; }
        }

        public void notify(bool isRunningAway, bool isDead)
        {
            
            this.enemyUI.updateImage(isRunningAway);
            
        }

    }
}
