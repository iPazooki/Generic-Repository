//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Data.Mapping
//{
//    public class PersonMapping : IEntityTypeConfiguration<YourEntity>
//    {
//        public void Configure(EntityTypeBuilder<YourEntity> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.Property(x => x.Name)
//                .IsRequired()
//                .HasMaxLength(250);
//        }
//    }
//}
