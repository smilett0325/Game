using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Infra
{
	public class Pagination
	{
		public Pagination(int pageNumber, int pageSize, int totalCount)
		{
			TotalCount = totalCount;
			PageSize = pageSize;
			PageNumber = pageNumber;
		}

		public int TotalCount { get; set; } //頁碼
		public int PageSize { get; set; } //每頁筆數
		public int PageNumber { get; set; } //符合條件總筆數

		//以下是可以算出來得屬性
		public int Pages => (int)Math.Ceiling((double)TotalCount / PageSize);//總頁數

		public bool HasPrevPage => PageNumber > 1; //要不要顯示上一頁
		public bool HasNextPage => PageNumber < Pages; //要不要顯示下一頁

	}

	public class PagedList<T> where T : class //存放但頁紀錄以及分頁資訊
	{

		public PagedList(IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
		{
			Data = data;
			Pagination = new Pagination(pageNumber, pageSize, totalCount);
		}

		public IEnumerable<T> Data { get; private set; }
		public Pagination Pagination { get; private set; }
	}
}