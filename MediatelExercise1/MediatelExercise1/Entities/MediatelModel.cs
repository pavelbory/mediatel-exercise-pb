namespace MediatelExercise1.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MediatelModel : DbContext
    {
        public MediatelModel()
            : base("name=MediatelModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<MapRequest> MapRequests { get; set; }
        public virtual DbSet<MapSearchResult> MapSearchResults { get; set; }
    }

}