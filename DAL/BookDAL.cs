using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Baithi3.Models;



namespace Baithi3.DAL
{
    public class BookDAL
    {
        public SqlConnection Ketnoi()
        {
            string st = ConfigurationManager.ConnectionStrings["ketnoidata"].ToString();
            SqlConnection con = new SqlConnection(st);
            return con;
        }

        public List<Sach> ListSach()
        {
            List<Sach> Sachs = new List<Sach>();
            SqlConnection con = Ketnoi();
            con.Open();
            string st = "select *from Book1";
            SqlCommand cm = new SqlCommand(st, con);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Sach sa = new Sach();
                sa.ID = int.Parse(dr["ID"].ToString());
                sa.TenSach = dr["TenSach"].ToString();
                sa.TacGia = dr["TacGia"].ToString();

                sa.NamXB = int.Parse(dr["NamXB"].ToString());
                sa.ImageCover = dr["ImageCover"].ToString();
                Sachs.Add(sa);
            }
            con.Close();
            return Sachs;

        }

        public void CreateBook(Sach sa)
        {
            SqlConnection con = Ketnoi();
            con.Open();
            string st = "insert into Book1 VALUES(@ID, @TenSach,@TacGia,@NamXB,@ImageCover)";
            SqlCommand cm = new SqlCommand(st, con);
            cm.Parameters.AddWithValue("ID", sa.ID);
            cm.Parameters.AddWithValue("TenSach", sa.TenSach);
            cm.Parameters.AddWithValue("TacGia", sa.TacGia);
            cm.Parameters.AddWithValue("NamXB", sa.NamXB);
            cm.Parameters.AddWithValue("ImageCover", sa.ImageCover);
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void EditBook(Sach sa)
        {
            SqlConnection con = Ketnoi();
            con.Open();
            string st = "update Book1 set TenSach=@TenSach,TacGia=@TacGia,NamXB=@NamXB,ImageCover= @ImageCover where ID=@ID";
            SqlCommand cm = new SqlCommand(st, con);
            cm.Parameters.AddWithValue("ID", sa.ID);
            cm.Parameters.AddWithValue("TenSach", sa.TenSach);
            cm.Parameters.AddWithValue("TacGia", sa.TacGia);
            cm.Parameters.AddWithValue("NamXB", sa.NamXB);
            cm.Parameters.AddWithValue("ImageCover", sa.ImageCover);
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteBook(int ID)
        {
            SqlConnection con = Ketnoi();
            con.Open();
            string st = "delete from Book1 where ID=@ID ";
            SqlCommand cm = new SqlCommand(st, con);
            cm.Parameters.AddWithValue("ID",ID);

            cm.ExecuteNonQuery();
            con.Close();
        }
        public List<Sach> FindBook(Sach s)
        {
            List<Sach> Sachs = new List<Sach>();
            SqlConnection con = Ketnoi();
            con.Open();
            string st = "select *from Book1 where TenSach=@TenSach";
            SqlCommand cm = new SqlCommand(st, con);
            cm.Parameters.AddWithValue("TenSach", s.TenSach);
            SqlDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                Sach sa = new Sach();
                sa.ID = int.Parse(dr["ID"].ToString());
                sa.TenSach = dr["TenSach"].ToString();
                sa.TacGia = dr["TacGia"].ToString();

                sa.NamXB = int.Parse(dr["NamXB"].ToString());
                sa.ImageCover = dr["ImageCover"].ToString();
                Sachs.Add(sa);
            }
            con.Close();
            return Sachs;

        }
    }
}