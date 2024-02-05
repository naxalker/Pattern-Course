using Assets.Visitor;
using System;
using UnityEngine;

public class Weight : IDisposable
{
    private const int OrkWeigth = 3;
    private const int HumanWeigth = 2;
    private const int ElfWeigth = 1;
    private const int RobotWeigth = 4;

    private int _value;

    private IEnemyDeathNotifier _enemyDeathNotifier;
    private IEnemySpawnNotifier _enemySpawnNotifier;

    private EnemyDeathVisitor _enemyDeathVisitor;
    private EnemySpawnVisitor _enemySpawnVisitor;

    public Weight(IEnemyDeathNotifier enemyDeathNotifier, IEnemySpawnNotifier enemySpawnNotifier)
    {
        _enemyDeathNotifier = enemyDeathNotifier;
        _enemyDeathNotifier.DeathNotified += OnEnemyKilled;
        
        _enemySpawnNotifier = enemySpawnNotifier;
        _enemySpawnNotifier.SpawnNotified += OnEnemySpawn;

        _enemyDeathVisitor = new EnemyDeathVisitor(this);
        _enemySpawnVisitor = new EnemySpawnVisitor(this);
    }

    public void Dispose()
    {
        _enemyDeathNotifier.DeathNotified -= OnEnemyKilled;
        _enemySpawnNotifier.SpawnNotified -= OnEnemySpawn;
    }

    public int Value
    {
        get => _value; 
        set => _value = Mathf.Max(value, 0);
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        _enemyDeathVisitor.Visit(enemy);
        Debug.Log($"Текущий вес: {Value}");
    }

    private void OnEnemySpawn(Enemy enemy)
    {
        _enemySpawnVisitor.Visit(enemy);
        Debug.Log($"Текущий вес: {Value}");
    }

    private class EnemySpawnVisitor : IEnemyVisitor
    {
        private Weight _weight;

        public EnemySpawnVisitor(Weight weight)
        {
            _weight = weight;
        }

        public void Visit(Ork ork) => _weight.Value += OrkWeigth;

        public void Visit(Human human) => _weight.Value += HumanWeigth;

        public void Visit(Elf elf) => _weight.Value += ElfWeigth;

        public void Visit(Robot robot) => _weight.Value += RobotWeigth;

        public void Visit(Enemy enemy) => Visit((dynamic)enemy);
    }

    private class EnemyDeathVisitor : IEnemyVisitor
    {
        private Weight _weight;

        public EnemyDeathVisitor(Weight weight)
        {
            _weight = weight;
        }

        public void Visit(Ork ork) => _weight.Value -= OrkWeigth;

        public void Visit(Human human) => _weight.Value -= HumanWeigth;

        public void Visit(Elf elf) => _weight.Value -= ElfWeigth;

        public void Visit(Robot robot) => _weight.Value -= RobotWeigth;

        public void Visit(Enemy enemy) => Visit((dynamic)enemy);
    }
}
