using System.Collections.Generic;
using Scripts.Enemies;

namespace Scripts
{
    public class EnemyCollection
    {
        List<Enemy> enemies = new List<Enemy>();

        EnemyCollection()
        {
            enemies.Add(new Krasue());
            enemies.Add(new Kongkoi());
        }
    }
}