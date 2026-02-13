using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Domain.Reports;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class ResguardoRepository : IResguardoRepository
    {
        private const string BaseSelect = @"
            SELECT
                r.Id,
                r.EquipoId,
                r.AdministrativoId,
                r.ResponsableSistemasId,
                r.CodigoInventario,
                r.FechaResguardo,
                r.Notas,

                -- Equipo
                e.Marca || ' ' || e.Modelo || ' - ' || IFNULL(e.NumeroSerie, '') AS EquipoDescripcion,

                -- Administrativo
                a.NombreCompleto AS AdministrativoNombre,
                ar.Nombre AS AreaNombre,

                -- Responsable de sistemas (administrativo ligado)
                aResp.NombreCompleto AS ResponsableSistemasNombre
            FROM Resguardos r
            INNER JOIN Equipos e ON e.Id = r.EquipoId
            INNER JOIN Administrativos a ON a.Id = r.AdministrativoId
            INNER JOIN Areas ar ON ar.Id = a.AreaId
            INNER JOIN ResponsablesSistemas rs ON rs.Id = r.ResponsableSistemasId
            INNER JOIN Administrativos aResp ON aResp.Id = rs.AdministrativoId
        ";

        public IEnumerable<Resguardo> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = BaseSelect + " ORDER BY r.CodigoInventario;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<Resguardo>();

            while (reader.Read())
            {
                lista.Add(MapResguardo(reader));
            }

            return lista;
        }

        public Resguardo? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = BaseSelect + " WHERE r.Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapResguardo(reader);

            return null;
        }

        public void Add(Resguardo resguardo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Resguardos
                (EquipoId, AdministrativoId, ResponsableSistemasId,
                 CodigoInventario, FechaResguardo, Notas)
                VALUES
                (@EquipoId, @AdministrativoId, @ResponsableSistemasId,
                 @CodigoInventario, @FechaResguardo, @Notas);
            ";

            cmd.Parameters.AddWithValue("@EquipoId", resguardo.EquipoId);
            cmd.Parameters.AddWithValue("@AdministrativoId", resguardo.AdministrativoId);
            cmd.Parameters.AddWithValue("@ResponsableSistemasId", resguardo.ResponsableSistemasId);
            cmd.Parameters.AddWithValue("@CodigoInventario", resguardo.CodigoInventario);
            cmd.Parameters.AddWithValue("@FechaResguardo", resguardo.FechaResguardo ?? "");
            cmd.Parameters.AddWithValue("@Notas", resguardo.Notas ?? "");

            cmd.ExecuteNonQuery();
        }

        public void Update(Resguardo resguardo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE Resguardos
                SET
                    EquipoId = @EquipoId,
                    AdministrativoId = @AdministrativoId,
                    ResponsableSistemasId = @ResponsableSistemasId,
                    -- Normalmente no cambiamos CodigoInventario
                    FechaResguardo = @FechaResguardo,
                    Notas = @Notas
                WHERE Id = @Id;
            ";

            cmd.Parameters.AddWithValue("@Id", resguardo.Id);
            cmd.Parameters.AddWithValue("@EquipoId", resguardo.EquipoId);
            cmd.Parameters.AddWithValue("@AdministrativoId", resguardo.AdministrativoId);
            cmd.Parameters.AddWithValue("@ResponsableSistemasId", resguardo.ResponsableSistemasId);
            cmd.Parameters.AddWithValue("@FechaResguardo", resguardo.FechaResguardo ?? "");
            cmd.Parameters.AddWithValue("@Notas", resguardo.Notas ?? "");

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Resguardos WHERE Id = @id;";
            cmd.Parameters.Add(new SqliteParameter("@id", id));
            cmd.ExecuteNonQuery();
        }

        public string? GetUltimoCodigoInventarioPorPrefijo(string prefijo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT CodigoInventario
                FROM Resguardos
                WHERE CodigoInventario LIKE @Prefijo || '%'
                ORDER BY CodigoInventario DESC
                LIMIT 1;
            ";
            cmd.Parameters.AddWithValue("@Prefijo", prefijo);

            var result = cmd.ExecuteScalar();
            return result == null ? null : Convert.ToString(result);
        }
        private static Resguardo MapResguardo(SqliteDataReader reader)
        {
            return new Resguardo
            {
                Id = reader.GetInt32(0),
                EquipoId = reader.GetInt32(1),
                AdministrativoId = reader.GetInt32(2),
                ResponsableSistemasId = reader.GetInt32(3),
                CodigoInventario = reader.GetString(4),
                FechaResguardo = reader.IsDBNull(5) ? null : reader.GetString(5),
                Notas = reader.IsDBNull(6) ? null : reader.GetString(6),

                EquipoDescripcion = reader.IsDBNull(7) ? null : reader.GetString(7),
                AdministrativoNombre = reader.IsDBNull(8) ? null : reader.GetString(8),
                AreaNombre = reader.IsDBNull(9) ? null : reader.GetString(9),
                ResponsableSistemasNombre = reader.IsDBNull(10) ? null : reader.GetString(10),
            };
        }

        public ResguardoReportModel? GetByIdForReport(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
        SELECT
            r.Id,
            r.CodigoInventario,
            r.FechaResguardo,
            r.Notas,

            -- Administrativo responsable del equipo
            a.NombreCompleto AS AdministrativoNombre,
            IFNULL(a.Puesto, '') AS AdministrativoPuesto,
            ar.Nombre AS AreaNombre,

            -- Responsable de sistemas (administrativo ligado)
            aResp.NombreCompleto AS ResponsableSistemasNombre,
            IFNULL(aResp.Puesto, '') AS ResponsableSistemasPuesto,

            -- Tipo de equipo
            te.Nombre AS TipoEquipoNombre,

            -- Equipo general
            e.Marca AS EquipoMarca,
            e.Modelo AS EquipoModelo,
            IFNULL(e.NumeroSerie, '') AS EquipoNumeroSerie,
            IFNULL(e.DireccionIp, '') AS EquipoDireccionIp,

            -- PC
            IFNULL(e.MemoriaRam, '') AS MemoriaRam,
            IFNULL(e.Procesador, '') AS Procesador,
            IFNULL(e.DiscoDuro, '') AS DiscoDuro,
            IFNULL(e.TieneLectorCd, 0) AS TieneLectorCd,
            IFNULL(e.EsPcEscritorio, 0) AS EsPcEscritorio,
            IFNULL(e.EsAllInOne, 0) AS EsAllInOne,

            -- Periféricos (si aplica)
            IFNULL(e.MarcaMonitor, '') AS MarcaMonitor,
            IFNULL(e.ModeloMonitor, '') AS ModeloMonitor,
            IFNULL(e.SerieMonitor, '') AS SerieMonitor,

            IFNULL(e.MarcaTeclado, '') AS MarcaTeclado,
            IFNULL(e.ModeloTeclado, '') AS ModeloTeclado,
            IFNULL(e.SerieTeclado, '') AS SerieTeclado,

            IFNULL(e.MarcaMouse, '') AS MarcaMouse,
            IFNULL(e.ModeloMouse, '') AS ModeloMouse,
            IFNULL(e.SerieMouse, '') AS SerieMouse,

            IFNULL(e.MarcaWebcam, '') AS MarcaWebcam,
            IFNULL(e.ModeloWebcam, '') AS ModeloWebcam,
            IFNULL(e.SerieWebcam, '') AS SerieWebcam,

            -- Impresora/Escáner
            IFNULL(e.TipoImpresion, '') AS TipoImpresion,

            -- Telefonía
            IFNULL(e.MacAddress, '') AS MacAddress,
            IFNULL(e.NumeroExtension, '') AS NumeroExtension,
            IFNULL(e.PrivilegiosLlamadas, '') AS PrivilegiosLlamadas

        FROM Resguardos r
        INNER JOIN Equipos e ON e.Id = r.EquipoId
        INNER JOIN TiposEquipos te ON te.Id = e.TipoEquipoId
        INNER JOIN Administrativos a ON a.Id = r.AdministrativoId
        INNER JOIN Areas ar ON ar.Id = a.AreaId
        INNER JOIN ResponsablesSistemas rs ON rs.Id = r.ResponsableSistemasId
        INNER JOIN Administrativos aResp ON aResp.Id = rs.AdministrativoId
        WHERE r.Id = @Id;
    ";

            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            // Map directo al modelo del reporte
            return new ResguardoReportModel
            {
                CodigoInventario = reader["CodigoInventario"].ToString() ?? "",
                FechaResguardo = reader["FechaResguardo"]?.ToString() ?? "",
                Notas = reader["Notas"]?.ToString() ?? "",

                AdministrativoNombre = reader["AdministrativoNombre"].ToString() ?? "",
                AdministrativoPuesto = reader["AdministrativoPuesto"].ToString() ?? "",
                AreaNombre = reader["AreaNombre"].ToString() ?? "",

                ResponsableSistemasNombre = reader["ResponsableSistemasNombre"].ToString() ?? "",
                ResponsableSistemasPuesto = reader["ResponsableSistemasPuesto"].ToString() ?? "",

                TipoEquipoNombre = reader["TipoEquipoNombre"].ToString() ?? "",

                EquipoMarca = reader["EquipoMarca"].ToString() ?? "",
                EquipoModelo = reader["EquipoModelo"].ToString() ?? "",
                EquipoNumeroSerie = reader["EquipoNumeroSerie"].ToString() ?? "",
                EquipoDireccionIp = reader["EquipoDireccionIp"].ToString() ?? "",

                MemoriaRam = reader["MemoriaRam"].ToString() ?? "",
                Procesador = reader["Procesador"].ToString() ?? "",
                DiscoDuro = reader["DiscoDuro"].ToString() ?? "",
                TieneLectorCd = Convert.ToInt32(reader["TieneLectorCd"]) == 1,
                EsPcEscritorio = Convert.ToInt32(reader["EsPcEscritorio"]) == 1,
                EsAllInOne = Convert.ToInt32(reader["EsAllInOne"]) == 1,

                MarcaMonitor = reader["MarcaMonitor"].ToString() ?? "",
                ModeloMonitor = reader["ModeloMonitor"].ToString() ?? "",
                SerieMonitor = reader["SerieMonitor"].ToString() ?? "",

                MarcaTeclado = reader["MarcaTeclado"].ToString() ?? "",
                ModeloTeclado = reader["ModeloTeclado"].ToString() ?? "",
                SerieTeclado = reader["SerieTeclado"].ToString() ?? "",

                MarcaMouse = reader["MarcaMouse"].ToString() ?? "",
                ModeloMouse = reader["ModeloMouse"].ToString() ?? "",
                SerieMouse = reader["SerieMouse"].ToString() ?? "",

                MarcaWebcam = reader["MarcaWebcam"].ToString() ?? "",
                ModeloWebcam = reader["ModeloWebcam"].ToString() ?? "",
                SerieWebcam = reader["SerieWebcam"].ToString() ?? "",

                TipoImpresion = reader["TipoImpresion"].ToString() ?? "",

                MacAddress = reader["MacAddress"].ToString() ?? "",
                NumeroExtension = reader["NumeroExtension"].ToString() ?? "",
                PrivilegiosLlamadas = reader["PrivilegiosLlamadas"].ToString() ?? ""
            };
        }

    }
}
