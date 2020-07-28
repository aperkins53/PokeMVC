using PokeMVC.Data;
using PokeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Services
{
    public class TrainerService
    {
        public bool CreateTrainer(TrainerCreate trainer)
        {
            var trainerToAdd =
                new Trainer()
                {
                    Name = trainer.Name,
                    IsGymLeader = trainer.IsGymLeader,
                    IsEliteFour = trainer.IsEliteFour,
                    IsChampion = trainer.IsChampion
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trainers.Add(trainerToAdd);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TrainerListItem> GetTrainers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allTrainers =
                    ctx
                        .Trainers
                        .Select(
                            t =>
                                new TrainerListItem
                                {
                                    TrainerId = t.TrainerId,
                                    Name = t.Name,
                                    IsGymLeader = t.IsGymLeader,
                                    IsEliteFour = t.IsEliteFour,
                                    IsChampion = t.IsChampion
                                });

                return allTrainers.ToArray();
            }
        }

        public TrainerDetail GetTrainerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trainer =
                    ctx
                        .Trainers
                        .Single(t => t.TrainerId == id);
                return
                    new TrainerDetail
                    {
                        TrainerId = trainer.TrainerId,
                        Name = trainer.Name,
                        IsGymLeader = trainer.IsGymLeader,
                        IsEliteFour = trainer.IsEliteFour,
                        IsChampion = trainer.IsChampion,
                        TrainerTeam = trainer.TrainerTeam
                    };
            }
        }

        public bool UpdateTrainer(TrainerEdit trainer)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trainerToUpdate =
                    ctx
                        .Trainers
                        .Single(t => t.TrainerId == trainer.TrainerId);

                trainerToUpdate.Name = trainer.Name;
                trainerToUpdate.IsGymLeader = trainer.IsGymLeader;
                trainerToUpdate.IsEliteFour = trainer.IsEliteFour;
                trainerToUpdate.IsChampion = trainer.IsChampion;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTrainer(int trainerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trainerToDelete =
                    ctx
                        .Trainers
                        .Single(t => t.TrainerId == trainerId);

                ctx.Trainers.Remove(trainerToDelete);

                return ctx.SaveChanges() == 1;
            }
        }

        //public ICollection<Pokemon> GetTrainerTeam(int trainerId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var trainer =
        //            ctx.Trainers.Single(t => t.TrainerId == trainerId);

        //        foreach (var pokemon in trainer.TrainerTeam)
        //        {
        //            new Pokemon
        //            {
        //                PokedexNumber = pokemon.PokedexNumber,
        //                Species = pokemon.Species,
        //                PrimaryType = pokemon.PrimaryType,
        //                SecondaryType = pokemon.SecondaryType,
        //                Level = pokemon.Level
        //            };
        //        }

        //        return trainer.TrainerTeam;
        //    };
        //}

        public bool AddPokemonToTrainerTeam(int pokemonId, int trainerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trainer = ctx.Trainers.Single(t => t.TrainerId == trainerId);

                var pokemonToAdd =
                    ctx.AllPokemon.Single(p => p.PokemonId == pokemonId);

                trainer.TrainerTeam.Add(pokemonToAdd);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
