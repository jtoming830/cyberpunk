using UnityEngine;
using System.Collections;

public class DBTest : MonoBehaviour {
    public static string dbName = "test.db";
    public static string tableName = "test";

    private void Start() {
        //InsertExample ();
        //or
        //InsertAllExample ();
        //ReadExample ();
    }

    void InsertAllExample () {
        var dbm = new DatabaseManager (dbName);
        dbm.OpenConnection ();
        var data = new ArrayList ();
        var buf = new ArrayList ();
        buf.Add (41); buf.Add (42); buf.Add (43);
        data.Add (buf);
        buf = new ArrayList ();
        buf.Add (51); buf.Add (52); buf.Add (53);
        data.Add (buf);
        dbm.InsertAll (tableName, data);
        dbm.CloseConnection ();
    }

    void InsertExample () {
        var dbm = new DatabaseManager (dbName);
        dbm.OpenConnection ();
        var data = new ArrayList ();
        data.Add (31); data.Add (32); data.Add (33);
        dbm.Insert (tableName, data);
        dbm.CloseConnection ();
    }

    //read from db example
    void ReadExample () {
        var dbm = new DatabaseManager (dbName);
        dbm.OpenConnection ();
        var a = dbm.Read (tableName, DatabaseManager.SELECT_ALL_COLLUMNS);
        foreach (var item in a) {
            var arr = item as ArrayList;
            foreach (var i in arr)
                Debug.Log("v " + i);
        }
        dbm.CloseConnection ();
    }
}