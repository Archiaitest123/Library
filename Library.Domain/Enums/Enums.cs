namespace Library.Domain.Enums;

public enum LoanStatus
{
    Active,
    Returned,
    Overdue,
    Lost
}

public enum ReservationStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Fulfilled,
    Expired
}

public enum FineStatus
{
    Pending,
    Paid,
    Waived
}

public enum NotificationType
{
    LoanDueReminder,
    LoanOverdue,
    ReservationReady,
    ReservationExpired,
    FineIssued,
    General
}

public enum MembershipType
{
    Basic,
    Standard,
    Premium,
    Student,
    Senior
}

public enum BookCondition
{
    New,
    Good,
    Fair,
    Poor,
    Damaged,
    Lost
}

public enum UserRole
{
    Member,
    Librarian,
    Admin
}
