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
    /// 門卡
    /// </summary>
    public class CardRepository : ICardRepository {

        private DatabaseContext DatabaseContext;
        private readonly IMapper Mapper;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        /// <param name="_Mapper">模型映射</param>
        public CardRepository(DatabaseContext _DatabaseContext, IMapper _Mapper) {
            DatabaseContext = _DatabaseContext;
            Mapper = _Mapper;
        }


        #region "讀取"

        /// <summary>
        /// 取得門卡
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        /// <returns>CardModel</returns>
        public async Task<CardModel> Get(int _Seq = 0) {
            var Model = await DatabaseContext.Card
                                             .AsQueryable()
                                             .Where(x => x.Seq == _Seq)
                                             .FirstOrDefaultAsync();

            if (Model == null) {
                Model = new CardModel();
            }

            return Model;
        }


        /// <summary>
        /// 取得門卡清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<CardViewModel> List, int Count)> GetList(CardListEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            string Keyword = _Entry.Keyword;

            var Query = DatabaseContext.Card.AsQueryable();

            // 關鍵字
            if (!string.IsNullOrEmpty(Keyword)) {
                Query = Query.Where(x => x.Note.Contains(Keyword));
            }

            int Count = await Query.CountAsync();

            var List = await Query.OrderBy(x => x.Seq)
                                  .Skip((PageNow - 1) * PageShow)
                                  .Take(PageShow)
                                  .ToListAsync();

            // 模型映射
            var ListVM = Mapper.Map<List<CardModel>, List<CardViewModel>>(List);

            ListVM.ForEach(x => {
                x.ActionTimeStr = x.ActionTime.ToString("yyyy-MM-dd HH:mm:ss");
            });

            return (ListVM, Count);
        }


        /// <summary>
        /// 取得門卡數量
        /// </summary>
        /// <returns>int</returns>
        public async Task<int> GetCount() {
            return await DatabaseContext.Card.AsQueryable().CountAsync();
        }


        /// <summary>
        /// 取得門卡指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>int</returns>
        public async Task<int> GetCursor(CardCursorEntry _Entry) {
            int Seq = 0;
            CardModel Model = new CardModel();

            var Query = DatabaseContext.Card.AsQueryable();

            if (_Entry.Direction) {
                Model = await Query.Where(x => x.Seq > _Entry.Seq)
                                   .OrderBy(x => x.Seq)
                                   .FirstOrDefaultAsync();
            } else {
                Model = await Query.Where(x => x.Seq < _Entry.Seq)
                                   .OrderByDescending(x => x.Seq)
                                   .FirstOrDefaultAsync();
            }

            if (Model != null) {
                Seq = Model.Seq;
            }

            return Seq;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門卡
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Set(CardModel _Model) {
            DatabaseContext.Card.Add(_Model);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "修改"

        /// <summary>
        /// 修改門卡
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Update(CardModel _Model) {
            var Temp = await DatabaseContext.Card.SingleAsync(x => x.ID == _Model.ID);

            if (Temp != null) {
                Temp.Note = _Model.Note;
                Temp.IsWork = _Model.IsWork;

                await DatabaseContext.SaveChangesAsync();
            }
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門卡
        /// </summary>
        /// <param name="_ID">門卡編號</param>
        /// <returns>Task</returns>
        public async Task Delete(int _ID = 0) {
            var Query = DatabaseContext.Card
                                       .AsQueryable()
                                       .Where(x => x.ID == _ID);

            DatabaseContext.Card.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 檢查門卡編號
        /// </summary>
        /// <param name="_ID">門卡編號</param>
        /// <returns>bool</returns>
        public async Task<bool> CheckID(int _ID = 0) {
            bool Flag = false;

            var Model = await DatabaseContext.Card
                                             .AsQueryable()
                                             .AsNoTracking()
                                             .Where(x => x.ID == _ID)
                                             .FirstOrDefaultAsync();

            if (Model != null) {
                Flag = true;
            }

            return Flag;
        }

        #endregion

    }
}