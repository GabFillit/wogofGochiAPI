using MeilleurDisponnible.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public abstract class CharacterEntity : EntityBase
    {
        public Config GameConfig { get; set; }
        public string Name { get; private set; }
        public Stat FedLevel { get; protected set; }
        public Stat HydratationLevel { get; protected set; }
        public Stat EnergyLevel { get; protected set; }
        public Stat HealthLevel { get; protected set; }
        public List<Actions> AviableActions { get; protected set; }
        public Status CurrentStatus { get; protected set; }

        public static List<string> _foodChoices;
        public static List<string> _drinkChoices;

        public CharacterEntity(string name, Config config)
        {
            GameConfig = config;
            Name = name;
            FedLevel = new Stat(config._startingFedLevel, config.statMinValue, config.statMaxValue);
            HydratationLevel = new Stat(config._startingHydratationLevel, config.statMinValue, config.statMaxValue);
            EnergyLevel = new Stat(config._startingEnergyLevel, config.statMinValue, config.statMaxValue);
            HealthLevel = new Stat(config._startingHealthLevel, config.statMinValue, config.statMaxValue);
            AviableActions = new List<Actions> { Actions.Eat, Actions.Drink, Actions.Sleep };
            CurrentStatus = Status.Idle;

            _foodChoices = GameConfig.FoodChoices.Keys.ToList().Select((key) =>
            {
                InputFoods value = GameConfig.FoodChoices[key];

                string foodChoiceMenuOption = $"{key} - {value.InputFood}";
                return foodChoiceMenuOption;

            }).ToList();

            _drinkChoices = GameConfig.DrinkChoices.Keys.ToList().Select((key) =>
            {
                InputDrinks value = GameConfig.DrinkChoices[key];

                string drinkChoiceMenuOption = $"{key} - {value.InputDrink}";
                return drinkChoiceMenuOption;

            }).ToList();
        }

        public abstract void Eat(Foods food);
        public abstract void Drink(Drinks dink);
        public abstract void UpdateStats();
        public abstract string HandleInput(Actions action);
        public virtual string DisplayStats()
        {

            var sb = new StringBuilder();
            sb.AppendLine($"Health: {HealthLevel.Current}");
            sb.AppendLine($"Energy: {EnergyLevel.Current}");
            sb.AppendLine($"Hunger: {FedLevel.Current}");
            sb.AppendLine($"Thirst: {HydratationLevel.Current}");

            return sb.ToString();
        }
    }

}
}
