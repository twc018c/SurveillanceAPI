using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Surveillance.Interfaces;
using Surveillance.Models;
using Surveillance.ViewModels;
using Surveillance.Schafold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Surveillance.Repositories {

    /// <summary>
    /// 門卡權限
    /// </summary>
    public class CardAuthorityRepository : ICardAuthorityRepository {

        private DatabaseContext DatabaseContext;
        private readonly IMapper Mapper;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        /// <param name="_Mapper">模型映射</param>
        public CardAuthorityRepository(DatabaseContext _DatabaseContext, IMapper _Mapper) {
            DatabaseContext = _DatabaseContext;
            Mapper = _Mapper;
        }


        #region "讀取"

        /// <summary>
        /// 取得門卡權限清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<CardAuthorityViewModel> List, int Count)> GetList(CardAuthorityEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            string Keyword = _Entry.Keyword;

            var Query = from CardAuthority in DatabaseContext.CardAuthority
                        join Card in DatabaseContext.Card on CardAuthority.CardID equals Card.ID into CardDefault
                        from Card in CardDefault.DefaultIfEmpty()
                        join Door in DatabaseContext.Door on CardAuthority.DoorID equals Door.ID into DoorDefault
                        from Door in DoorDefault.DefaultIfEmpty()
                        select new CardAuthorityViewModel {
                            // Model
                            Seq = CardAuthority.Seq,
                            CardID = CardAuthority.CardID,
                            DoorID = CardAuthority.DoorID,
                            // ViewModel
                            CardNote = Card.Note,
                            DoorName = Door.Name
                        };

            // 關鍵字
            if (!string.IsNullOrEmpty(Keyword)) {
                Query = Query.Where(x => x.DoorName.Contains(Keyword));
            }

            int Count = await Query.CountAsync();

            var List = await Query.OrderBy(x => x.Seq)
                                  .Skip((PageNow - 1) * PageShow)
                                  .Take(PageShow)
                                  .ToListAsync();

            return (List, Count);
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門卡權限
        /// </summary>
        /// <param name="_List">清單</param>
        /// <returns>Task</returns>
        public async Task Set(List<CardAuthorityModel> _List) {
            DatabaseContext.CardAuthority.AddRange(_List);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門卡權限 (依門卡編號)
        /// </summary>
        /// <param name="_CardID">門卡編號</param>
        /// <returns>Task</returns>
        public async Task DeleteByCard(int _CardID = 0) {
            var Query = DatabaseContext.CardAuthority
                                       .AsQueryable()
                                       .Where(x => x.CardID == _CardID);

            DatabaseContext.CardAuthority.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 刪除門卡權限 (依門鎖編號)
        /// </summary>
        /// <param name="_DoorID">門鎖編號</param>
        /// <returns>Task</returns>
        public async Task DeleteByDoor(int _DoorID = 0) {
            var Query = DatabaseContext.CardAuthority
                                       .AsQueryable()
                                       .Where(x => x.DoorID == _DoorID);

            DatabaseContext.CardAuthority.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 檢查門卡權限
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>bool</returns>
        public async Task<bool> Check(CardAuthorityCheckEntry _Entry) {
            bool Flag = false;

            var Model = await DatabaseContext.CardAuthority
                                             .AsQueryable()
                                             .AsNoTracking()
                                             .Where(x => x.CardID == _Entry.CardID && x.DoorID == _Entry.DoorID)
                                             .FirstOrDefaultAsync();

            if (Model != null) {
                Flag = true;
            }

            return Flag;
        }

        #endregion

    }
}