﻿using System;

namespace NPoco.Expressions
{
    public class OracleExpression<T> : SqlExpression<T>
    {
        public OracleExpression(IDatabase database, PocoData pocoData, bool prefixTableName) : base(database, pocoData, prefixTableName)
        {
        }

        protected override string GetDateTimeSql(string memberName, object m)
        {
            //Oracle
            // http://blog.csdn.net/gccr/article/details/1802740
            string sql = null;
            switch (memberName)
            {
                case "Year": sql = string.Format("EXTRACT(YEAR FROM TIMESTAMP {0})", m); break;
                case "Month": sql = string.Format("EXTRACT(MONTH FROM TIMESTAMP {0})", m); break;
                case "Day": sql = string.Format("EXTRACT(DAY FROM TIMESTAMP {0})", m); break;
                case "Hour": sql = string.Format("EXTRACT(HOUR FROM TIMESTAMP {0})", m); break;
                case "Minute": sql = string.Format("EXTRACT(MINUTE FROM TIMESTAMP {0})", m); break;
                case "Second": sql = string.Format("EXTRACT(SECOND FROM TIMESTAMP {0})", m); break;
                //case "HasValue": sql = m.ToString() + " IS NOT NULL "; break;
                default: throw new NotSupportedException("Not Supported " + memberName);
            }
            return sql;
        }
    }
    
}