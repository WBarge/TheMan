using System;

namespace Utilites
{
	public class DateRange
	{

		#region Constants
		#endregion Constants

		#region Local Vars
		#endregion Local Vars

		#region Properties

		/// <summary>
		/// Gets or sets the start.
		/// </summary>
		/// <value>
		/// The start.
		/// </value>
		public DateTime Start { get; set; }
		/// <summary>
		/// Gets or sets the end.
		/// </summary>
		/// <value>
		/// The end.
		/// </value>
		public DateTime End { get; set; }

		#endregion Properties

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DateRange"/> class.
		/// </summary>
		public DateRange()
		{
			CommonInit();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DateRange"/> class.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		public DateRange(string start, string end) :this(start.ToDateTime(DateTime.MinValue),end.ToDateTime(DateTime.MaxValue))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DateRange"/> class.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		public DateRange(DateTime? start, DateTime? end) : this(start.ToDateTime(DateTime.MinValue), end.ToDateTime(DateTime.MaxValue))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DateRange"/> class.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		public DateRange(DateTime start, DateTime end) : this()
		{
			Start = start;
			End = end;
		}

		#endregion Constructors

		#region Methods

		#region Private Methods

		/// <summary>
		/// Commons the initialize.
		/// </summary>
		private void CommonInit()
		{
			Start = DateTime.MinValue;
			End = DateTime.MaxValue;
		}

		#endregion

		#region Protected Methods

		#endregion Protected Methods

		#region Public Methods

		/// <summary>
		/// Does the range overlap the as of date inclusive of the start and end
		/// </summary>
		/// <param name="asOfDate">The date to check.</param>
		/// <returns>
		///     true - the date is within the daterange 
		///     false - the date is no within the daterange
		/// </returns>
		public bool Overlaps(DateTime asOfDate, bool includeEndPoints = true)
		{
			bool returnValue = false;
			if (includeEndPoints)
			{
				returnValue = OverlapsInclusive(asOfDate);
			}
			else
			{
				returnValue = OverlapsExclusive(asOfDate);
			}
			return (returnValue);
		}

		/// <summary>
		/// Overlapses the specified range inclusive.
		/// </summary>
		/// <param name="range">The range.</param>
		/// <returns>
		///     true - the ranges overlap
		///     false - the ranges do not overlag
		/// </returns>
		public bool Overlaps(DateRange range)
		{
			return (Overlaps(range.Start) || Overlaps(range.End));
		}

		/// <summary>
		/// Is the date range inside this date range
		/// </summary>
		/// <param name="range">The range.</param>
		/// <param name="includeEndPoints">if set to <see langword="true" /> [include end points].</param>
		/// <returns>
		///     true - the range is within this range
		///     false - the range is not within this range
		/// </returns>
		public bool WithIn(DateRange range, bool includeEndPoints = true)
		{
			bool returnValue = false;
			if (includeEndPoints)
			{
				returnValue = (OverlapsInclusive(range.Start) && OverlapsInclusive(range.End));
			}
			else
			{
				returnValue = (OverlapsExclusive(range.Start) && OverlapsExclusive(range.End));
			}
			return (returnValue);
		}

		/// <summary>
		/// Does the range overlap the as of date exclusive of the start and end
		/// </summary>
		/// <param name="asOfDate">The date to check.</param>
		/// <returns>
		///     true - the date is within the daterange 
		///     false - the date is no within the daterange
		/// </returns>
		public bool OverlapsExclusive(DateTime asOfDate)
		{
			bool returnValue = asOfDate.Date > Start.Date && asOfDate.Date < End.Date;
			return (returnValue);
		}

		/// <summary>
		/// Does the range overlap the as of date inclusive of the start and end
		/// </summary>
		/// <param name="asOfDate">The date to check.</param>
		/// <returns>
		///     true - the date is within the daterange 
		///     false - the date is no within the daterange
		/// </returns>
		public bool OverlapsInclusive(DateTime asOfDate)
		{
			bool returnValue = asOfDate.Date >= Start.Date && asOfDate.Date <= End.Date;
			return (returnValue);
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return $"{Start.ToShortDateString()}-{End.ToShortDateString()}";
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.
		/// </returns>
		public override bool Equals(object obj)
		{
			bool returnValue = false;

			if (obj is DateRange)
			{
				DateRange incoming = obj as DateRange;
				returnValue = (Start.Equals(incoming.Start) && End.Equals(incoming.End));
			}
			else
			{
				returnValue = base.Equals(obj);
			}
			return (returnValue);
		}

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="d1">The d1.</param>
        /// <param name="d2">The d2.</param>
        /// <returns>
        ///   <see langword="true" /> if the left hand (d1) equals the right hand (d2) otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator == (DateRange d1, DateRange d2)
	    {
	        return d1.Equals(d2);
	    }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="d1">The d1.</param>
        /// <param name="d2">The d2.</param>
        /// <returns>
        ///   <see langword="true" /> if the left hand (d1) DOES NOT equals the right hand (d2) otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator !=(DateRange d1, DateRange d2)
	    {
	        return !d1.Equals(d2);
	    }

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			unchecked
			{
				int result = 17;
				result = result * 23 + Start.GetHashCode();
				result = result * 23 + End.GetHashCode();
				return result;
			}
		}

		#endregion Public Methods

		#endregion Methods
	
	}
}
