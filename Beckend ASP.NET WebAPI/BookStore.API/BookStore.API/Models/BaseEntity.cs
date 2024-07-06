using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}