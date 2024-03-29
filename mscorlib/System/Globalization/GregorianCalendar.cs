﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Globalization
{
	/// <summary>Represents the Gregorian calendar.</summary>
	// Token: 0x02000390 RID: 912
	[ComVisible(true)]
	[Serializable]
	public class GregorianCalendar : Calendar
	{
		// Token: 0x06002E3A RID: 11834 RVA: 0x000B1350 File Offset: 0x000AF550
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			if (this.m_type < GregorianCalendarTypes.Localized || this.m_type > GregorianCalendarTypes.TransliteratedFrench)
			{
				throw new SerializationException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Serialization_MemberOutOfRange"), "type", "GregorianCalendar"));
			}
		}

		/// <summary>Gets the earliest date and time supported by the <see cref="T:System.Globalization.GregorianCalendar" /> type.</summary>
		/// <returns>The earliest date and time supported by the <see cref="T:System.Globalization.GregorianCalendar" /> type, which is the first moment of January 1, 0001 C.E. and is equivalent to <see cref="F:System.DateTime.MinValue" />.</returns>
		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x06002E3B RID: 11835 RVA: 0x000B1389 File Offset: 0x000AF589
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return DateTime.MinValue;
			}
		}

		/// <summary>Gets the latest date and time supported by the <see cref="T:System.Globalization.GregorianCalendar" /> type.</summary>
		/// <returns>The latest date and time supported by the <see cref="T:System.Globalization.GregorianCalendar" /> type, which is the last moment of December 31, 9999 C.E. and is equivalent to <see cref="F:System.DateTime.MaxValue" />.</returns>
		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x06002E3C RID: 11836 RVA: 0x000B1390 File Offset: 0x000AF590
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		/// <summary>Gets a value that indicates whether the current calendar is solar-based, lunar-based, or a combination of both.</summary>
		/// <returns>Always returns <see cref="F:System.Globalization.CalendarAlgorithmType.SolarCalendar" />.</returns>
		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x06002E3D RID: 11837 RVA: 0x000B1397 File Offset: 0x000AF597
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		// Token: 0x06002E3E RID: 11838 RVA: 0x000B139A File Offset: 0x000AF59A
		internal static Calendar GetDefaultInstance()
		{
			if (GregorianCalendar.s_defaultInstance == null)
			{
				GregorianCalendar.s_defaultInstance = new GregorianCalendar();
			}
			return GregorianCalendar.s_defaultInstance;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Globalization.GregorianCalendar" /> class using the default <see cref="T:System.Globalization.GregorianCalendarTypes" /> value.</summary>
		// Token: 0x06002E3F RID: 11839 RVA: 0x000B13B8 File Offset: 0x000AF5B8
		public GregorianCalendar() : this(GregorianCalendarTypes.Localized)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Globalization.GregorianCalendar" /> class using the specified <see cref="T:System.Globalization.GregorianCalendarTypes" /> value.</summary>
		/// <param name="type">The <see cref="T:System.Globalization.GregorianCalendarTypes" /> value that denotes which language version of the calendar to create.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="type" /> is not a member of the <see cref="T:System.Globalization.GregorianCalendarTypes" /> enumeration.</exception>
		// Token: 0x06002E40 RID: 11840 RVA: 0x000B13C4 File Offset: 0x000AF5C4
		public GregorianCalendar(GregorianCalendarTypes type)
		{
			if (type < GregorianCalendarTypes.Localized || type > GregorianCalendarTypes.TransliteratedFrench)
			{
				throw new ArgumentOutOfRangeException("type", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					GregorianCalendarTypes.Localized,
					GregorianCalendarTypes.TransliteratedFrench
				}));
			}
			this.m_type = type;
		}

		/// <summary>Gets or sets the <see cref="T:System.Globalization.GregorianCalendarTypes" /> value that denotes the language version of the current <see cref="T:System.Globalization.GregorianCalendar" />.</summary>
		/// <returns>A <see cref="T:System.Globalization.GregorianCalendarTypes" /> value that denotes the language version of the current <see cref="T:System.Globalization.GregorianCalendar" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value specified in a set operation is not a member of the <see cref="T:System.Globalization.GregorianCalendarTypes" /> enumeration.</exception>
		/// <exception cref="T:System.InvalidOperationException">In a set operation, the current instance is read-only.</exception>
		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06002E41 RID: 11841 RVA: 0x000B1415 File Offset: 0x000AF615
		// (set) Token: 0x06002E42 RID: 11842 RVA: 0x000B141D File Offset: 0x000AF61D
		public virtual GregorianCalendarTypes CalendarType
		{
			get
			{
				return this.m_type;
			}
			set
			{
				base.VerifyWritable();
				if (value - GregorianCalendarTypes.Localized <= 1 || value - GregorianCalendarTypes.MiddleEastFrench <= 3)
				{
					this.m_type = value;
					return;
				}
				throw new ArgumentOutOfRangeException("m_type", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
			}
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x06002E43 RID: 11843 RVA: 0x000B144E File Offset: 0x000AF64E
		internal override int ID
		{
			get
			{
				return (int)this.m_type;
			}
		}

		// Token: 0x06002E44 RID: 11844 RVA: 0x000B1458 File Offset: 0x000AF658
		internal virtual int GetDatePart(long ticks, int part)
		{
			int i = (int)(ticks / 864000000000L);
			int num = i / 146097;
			i -= num * 146097;
			int num2 = i / 36524;
			if (num2 == 4)
			{
				num2 = 3;
			}
			i -= num2 * 36524;
			int num3 = i / 1461;
			i -= num3 * 1461;
			int num4 = i / 365;
			if (num4 == 4)
			{
				num4 = 3;
			}
			if (part == 0)
			{
				return num * 400 + num2 * 100 + num3 * 4 + num4 + 1;
			}
			i -= num4 * 365;
			if (part == 1)
			{
				return i + 1;
			}
			int[] array = (num4 == 3 && (num3 != 24 || num2 == 3)) ? GregorianCalendar.DaysToMonth366 : GregorianCalendar.DaysToMonth365;
			int num5 = i >> 6;
			while (i >= array[num5])
			{
				num5++;
			}
			if (part == 2)
			{
				return num5;
			}
			return i - array[num5 - 1] + 1;
		}

		// Token: 0x06002E45 RID: 11845 RVA: 0x000B153C File Offset: 0x000AF73C
		internal static long GetAbsoluteDate(int year, int month, int day)
		{
			if (year >= 1 && year <= 9999 && month >= 1 && month <= 12)
			{
				int[] array = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? GregorianCalendar.DaysToMonth366 : GregorianCalendar.DaysToMonth365;
				if (day >= 1 && day <= array[month] - array[month - 1])
				{
					int num = year - 1;
					int num2 = num * 365 + num / 4 - num / 100 + num / 400 + array[month - 1] + day - 1;
					return (long)num2;
				}
			}
			throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
		}

		// Token: 0x06002E46 RID: 11846 RVA: 0x000B15C9 File Offset: 0x000AF7C9
		internal virtual long DateToTicks(int year, int month, int day)
		{
			return GregorianCalendar.GetAbsoluteDate(year, month, day) * 864000000000L;
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of months away from the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to which to add months.</param>
		/// <param name="months">The number of months to add.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of months to the specified <see cref="T:System.DateTime" />.</returns>
		/// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="months" /> is less than -120000.  
		/// -or-  
		/// <paramref name="months" /> is greater than 120000.</exception>
		// Token: 0x06002E47 RID: 11847 RVA: 0x000B15E0 File Offset: 0x000AF7E0
		public override DateTime AddMonths(DateTime time, int months)
		{
			if (months < -120000 || months > 120000)
			{
				throw new ArgumentOutOfRangeException("months", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), -120000, 120000));
			}
			int num;
			int num2;
			int num3;
			time.GetDatePart(out num, out num2, out num3);
			int num4 = num2 - 1 + months;
			if (num4 >= 0)
			{
				num2 = num4 % 12 + 1;
				num += num4 / 12;
			}
			else
			{
				num2 = 12 + (num4 + 1) % 12;
				num += (num4 - 11) / 12;
			}
			int[] array = (num % 4 == 0 && (num % 100 != 0 || num % 400 == 0)) ? GregorianCalendar.DaysToMonth366 : GregorianCalendar.DaysToMonth365;
			int num5 = array[num2] - array[num2 - 1];
			if (num3 > num5)
			{
				num3 = num5;
			}
			long ticks = this.DateToTicks(num, num2, num3) + time.Ticks % 864000000000L;
			Calendar.CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return new DateTime(ticks);
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of years away from the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to which to add years.</param>
		/// <param name="years">The number of years to add.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of years to the specified <see cref="T:System.DateTime" />.</returns>
		/// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range.</exception>
		// Token: 0x06002E48 RID: 11848 RVA: 0x000B16D9 File Offset: 0x000AF8D9
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.AddMonths(time, years * 12);
		}

		/// <summary>Returns the day of the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 31 that represents the day of the month in <paramref name="time" />.</returns>
		// Token: 0x06002E49 RID: 11849 RVA: 0x000B16E6 File Offset: 0x000AF8E6
		public override int GetDayOfMonth(DateTime time)
		{
			return time.Day;
		}

		/// <summary>Returns the day of the week in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>A <see cref="T:System.DayOfWeek" /> value that represents the day of the week in <paramref name="time" />.</returns>
		// Token: 0x06002E4A RID: 11850 RVA: 0x000B16EF File Offset: 0x000AF8EF
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return (DayOfWeek)(time.Ticks / 864000000000L + 1L) % (DayOfWeek)7;
		}

		/// <summary>Returns the day of the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 366 that represents the day of the year in <paramref name="time" />.</returns>
		// Token: 0x06002E4B RID: 11851 RVA: 0x000B1708 File Offset: 0x000AF908
		public override int GetDayOfYear(DateTime time)
		{
			return time.DayOfYear;
		}

		/// <summary>Returns the number of days in the specified month in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of days in the specified month in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002E4C RID: 11852 RVA: 0x000B1714 File Offset: 0x000AF914
		public override int GetDaysInMonth(int year, int month, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					9999
				}));
			}
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Month"));
			}
			int[] array = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? GregorianCalendar.DaysToMonth366 : GregorianCalendar.DaysToMonth365;
			return array[month] - array[month - 1];
		}

		/// <summary>Returns the number of days in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of days in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002E4D RID: 11853 RVA: 0x000B17C8 File Offset: 0x000AF9C8
		public override int GetDaysInYear(int year, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
			}
			if (year % 4 != 0 || (year % 100 == 0 && year % 400 != 0))
			{
				return 365;
			}
			return 366;
		}

		/// <summary>Returns the era in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the era in <paramref name="time" />.</returns>
		// Token: 0x06002E4E RID: 11854 RVA: 0x000B184B File Offset: 0x000AFA4B
		public override int GetEra(DateTime time)
		{
			return 1;
		}

		/// <summary>Gets the list of eras in the <see cref="T:System.Globalization.GregorianCalendar" />.</summary>
		/// <returns>An array of integers that represents the eras in the <see cref="T:System.Globalization.GregorianCalendar" />.</returns>
		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x06002E4F RID: 11855 RVA: 0x000B184E File Offset: 0x000AFA4E
		public override int[] Eras
		{
			get
			{
				return new int[]
				{
					1
				};
			}
		}

		/// <summary>Returns the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 12 that represents the month in <paramref name="time" />.</returns>
		// Token: 0x06002E50 RID: 11856 RVA: 0x000B185A File Offset: 0x000AFA5A
		public override int GetMonth(DateTime time)
		{
			return time.Month;
		}

		/// <summary>Returns the number of months in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of months in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002E51 RID: 11857 RVA: 0x000B1864 File Offset: 0x000AFA64
		public override int GetMonthsInYear(int year, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year >= 1 && year <= 9999)
			{
				return 12;
			}
			throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
		}

		/// <summary>Returns the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the year in <paramref name="time" />.</returns>
		// Token: 0x06002E52 RID: 11858 RVA: 0x000B18CA File Offset: 0x000AFACA
		public override int GetYear(DateTime time)
		{
			return time.Year;
		}

		/// <summary>Determines whether the specified date in the specified era is a leap day.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="day">An integer from 1 to 31 that represents the day.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>
		///   <see langword="true" /> if the specified day is a leap day; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="day" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002E53 RID: 11859 RVA: 0x000B18D4 File Offset: 0x000AFAD4
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					12
				}));
			}
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					9999
				}));
			}
			if (day < 1 || day > this.GetDaysInMonth(year, month))
			{
				throw new ArgumentOutOfRangeException("day", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					this.GetDaysInMonth(year, month)
				}));
			}
			return this.IsLeapYear(year) && (month == 2 && day == 29);
		}

		/// <summary>Calculates the leap month for a specified year and era.</summary>
		/// <param name="year">A year.</param>
		/// <param name="era">An era. Specify either <see cref="F:System.Globalization.GregorianCalendar.ADEra" /> or <see langword="GregorianCalendar.Eras[Calendar.CurrentEra]" />.</param>
		/// <returns>Always 0 because the Gregorian calendar does not recognize leap months.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is less than the Gregorian calendar year 1 or greater than the Gregorian calendar year 9999.  
		/// -or-  
		/// <paramref name="era" /> is not <see cref="F:System.Globalization.GregorianCalendar.ADEra" /> or <see langword="GregorianCalendar.Eras[Calendar.CurrentEra]" />.</exception>
		// Token: 0x06002E54 RID: 11860 RVA: 0x000B19D0 File Offset: 0x000AFBD0
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
			}
			return 0;
		}

		/// <summary>Determines whether the specified month in the specified year in the specified era is a leap month.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>This method always returns <see langword="false" />, unless overridden by a derived class.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002E55 RID: 11861 RVA: 0x000B1A38 File Offset: 0x000AFC38
		public override bool IsLeapMonth(int year, int month, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
			}
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					12
				}));
			}
			return false;
		}

		/// <summary>Determines whether the specified year in the specified era is a leap year.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>
		///   <see langword="true" /> if the specified year is a leap year; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002E56 RID: 11862 RVA: 0x000B1AD4 File Offset: 0x000AFCD4
		public override bool IsLeapYear(int year, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year >= 1 && year <= 9999)
			{
				return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
			}
			throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is set to the specified date and time in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="day">An integer from 1 to 31 that represents the day.</param>
		/// <param name="hour">An integer from 0 to 23 that represents the hour.</param>
		/// <param name="minute">An integer from 0 to 59 that represents the minute.</param>
		/// <param name="second">An integer from 0 to 59 that represents the second.</param>
		/// <param name="millisecond">An integer from 0 to 999 that represents the millisecond.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that is set to the specified date and time in the current era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="day" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="hour" /> is less than zero or greater than 23.  
		/// -or-  
		/// <paramref name="minute" /> is less than zero or greater than 59.  
		/// -or-  
		/// <paramref name="second" /> is less than zero or greater than 59.  
		/// -or-  
		/// <paramref name="millisecond" /> is less than zero or greater than 999.</exception>
		// Token: 0x06002E57 RID: 11863 RVA: 0x000B1B51 File Offset: 0x000AFD51
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			if (era == 0 || era == 1)
			{
				return new DateTime(year, month, day, hour, minute, second, millisecond);
			}
			throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
		}

		// Token: 0x06002E58 RID: 11864 RVA: 0x000B1B81 File Offset: 0x000AFD81
		internal override bool TryToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era, out DateTime result)
		{
			if (era == 0 || era == 1)
			{
				return DateTime.TryCreate(year, month, day, hour, minute, second, millisecond, out result);
			}
			result = DateTime.MinValue;
			return false;
		}

		/// <summary>Gets or sets the last year of a 100-year range that can be represented by a 2-digit year.</summary>
		/// <returns>The last year of a 100-year range that can be represented by a 2-digit year.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value specified in a set operation is less than 99.  
		///  -or-  
		///  The value specified in a set operation is greater than <see langword="MaxSupportedDateTime.Year" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">In a set operation, the current instance is read-only.</exception>
		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06002E59 RID: 11865 RVA: 0x000B1BAC File Offset: 0x000AFDAC
		// (set) Token: 0x06002E5A RID: 11866 RVA: 0x000B1BD4 File Offset: 0x000AFDD4
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 2029);
				}
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > 9999)
				{
					throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 99, 9999));
				}
				this.twoDigitYearMax = value;
			}
		}

		/// <summary>Converts the specified year to a four-digit year by using the <see cref="P:System.Globalization.GregorianCalendar.TwoDigitYearMax" /> property to determine the appropriate century.</summary>
		/// <param name="year">A two-digit or four-digit integer that represents the year to convert.</param>
		/// <returns>An integer that contains the four-digit representation of <paramref name="year" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002E5B RID: 11867 RVA: 0x000B1C2C File Offset: 0x000AFE2C
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
			}
			return base.ToFourDigitYear(year);
		}

		/// <summary>Represents the current era. This field is constant.</summary>
		// Token: 0x04001367 RID: 4967
		public const int ADEra = 1;

		// Token: 0x04001368 RID: 4968
		internal const int DatePartYear = 0;

		// Token: 0x04001369 RID: 4969
		internal const int DatePartDayOfYear = 1;

		// Token: 0x0400136A RID: 4970
		internal const int DatePartMonth = 2;

		// Token: 0x0400136B RID: 4971
		internal const int DatePartDay = 3;

		// Token: 0x0400136C RID: 4972
		internal const int MaxYear = 9999;

		// Token: 0x0400136D RID: 4973
		internal GregorianCalendarTypes m_type;

		// Token: 0x0400136E RID: 4974
		internal static readonly int[] DaysToMonth365 = new int[]
		{
			0,
			31,
			59,
			90,
			120,
			151,
			181,
			212,
			243,
			273,
			304,
			334,
			365
		};

		// Token: 0x0400136F RID: 4975
		internal static readonly int[] DaysToMonth366 = new int[]
		{
			0,
			31,
			60,
			91,
			121,
			152,
			182,
			213,
			244,
			274,
			305,
			335,
			366
		};

		// Token: 0x04001370 RID: 4976
		private static volatile Calendar s_defaultInstance;

		// Token: 0x04001371 RID: 4977
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 2029;
	}
}
