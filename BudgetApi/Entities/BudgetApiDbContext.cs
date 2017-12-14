namespace BudgetApi.Entities
{
    using System.Data.Entity;

    public partial class BudgetApiDbContext : DbContext
    {
        public BudgetApiDbContext()
            : base("name=BudgetApiDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountBalance> AccountBalances { get; set; }
        public virtual DbSet<AccountBalanceHistory> AccountBalanceHistories { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseSchedule> ExpenseSchedules { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<IncomeSchedule> IncomeSchedules { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<AccessLog> AccessLogs { get; set; }
        public virtual DbSet<ChangeLog> ChangeLogs { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.AccountBalances)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.Account_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.AccountBalanceHistories)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.Account_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.Account_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Incomes)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.Account_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.UserAccounts)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.Account_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountBalance>()
                .Property(e => e.Balance)
                .HasPrecision(9, 2);

            modelBuilder.Entity<AccountBalance>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccountBalance>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccountBalanceHistory>()
                .Property(e => e.Balance)
                .HasPrecision(9, 2);

            modelBuilder.Entity<AccountBalanceHistory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccountBalanceHistory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccountRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AccountRole>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AccountRole>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccountRole>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccountRole>()
                .HasMany(e => e.UserAccounts)
                .WithRequired(e => e.AccountRole)
                .HasForeignKey(e => e.AccountRole_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Expense>()
                .Property(e => e.MinimumDue)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Expense>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Expense>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Expense>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Expense)
                .HasForeignKey(e => e.Payee_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExpenseSchedule>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseSchedule>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseSchedule>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseSchedule>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseSchedule>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.ExpenseSchedule)
                .HasForeignKey(e => e.ExpenseSchedule_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Income>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Income>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Income>()
                .Property(e => e.GrossAmount)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Income>()
                .Property(e => e.NetAmount)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Income>()
                .Property(e => e.TaxRate)
                .HasPrecision(2, 2);

            modelBuilder.Entity<Income>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Income>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<IncomeSchedule>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<IncomeSchedule>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<IncomeSchedule>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<IncomeSchedule>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<IncomeSchedule>()
                .HasMany(e => e.Incomes)
                .WithRequired(e => e.IncomeSchedule)
                .HasForeignKey(e => e.IncomeSchedule_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.AmountPaid)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordHash)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.AccessLogs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Fk);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAccounts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserRole)
                .HasForeignKey(e => e.UserRole_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccessLog>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLog>()
                .Property(e => e.Device)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLog>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLog>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.OldValue)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.NewValue)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.ErrorMessage)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}
