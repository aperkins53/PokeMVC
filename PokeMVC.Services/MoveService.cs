using PokeMVC.Data;
using PokeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Services
{
    public class MoveService
    {
        public bool CreateMove(MoveCreate move)
        {
            var moveToAdd =
                new Move()
                {
                    MoveName = move.MoveName,
                    MovePower = move.MovePower,
                    MoveAccuracy = move.MoveAccuracy,
                    MovePP = move.MovePP,
                    ExtraEffect = move.ExtraEffect
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Moves.Add(moveToAdd);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MoveListItem> GetMoves()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allMoves =
                    ctx
                        .Moves
                        .Select(
                            m =>
                                new MoveListItem
                                {
                                    MoveId = m.MoveId,
                                    MoveName = m.MoveName,
                                    MovePower = m.MovePower,
                                    MoveAccuracy = m.MoveAccuracy,
                                    MovePP = m.MovePP,
                                    ExtraEffect = m.ExtraEffect
                                });

                return allMoves.ToArray();
            }
        }

        public MoveDetail GetMoveById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var move =
                    ctx
                        .Moves
                        .Single(m => m.MoveId == id);
                return
                    new MoveDetail
                    {
                        MoveId = move.MoveId,
                        MoveName = move.MoveName,
                        MovePower = move.MovePower,
                        MoveAccuracy = move.MoveAccuracy,
                        MovePP = move.MovePP,
                        ExtraEffect = move.ExtraEffect
                    };
            }
        }

        public bool UpdateMove(MoveEdit move)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var moveToUpdate =
                    ctx
                        .Moves
                        .Single(m => m.MoveId == move.MoveId);

                moveToUpdate.MoveName = move.MoveName;
                moveToUpdate.MovePower = move.MovePower;
                moveToUpdate.MoveAccuracy = move.MoveAccuracy;
                moveToUpdate.MovePP = move.MovePP;
                moveToUpdate.ExtraEffect = move.ExtraEffect;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMove(int moveId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var moveToDelete =
                    ctx
                        .Moves
                        .Single(m => m.MoveId == moveId);

                ctx.Moves.Remove(moveToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
