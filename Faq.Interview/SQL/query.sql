 select emp.*, case when emp.[Serial No] = 1 then 'Max Salary' else cast(e.MaxSalary - emp.Salary as varchar) end as [Salary Difference] from
  (select Rank, max(salary) as MaxSalary from Employee group by Rank) as e
  inner join 
  (select dense_rank() over (partition by Rank order by Salary desc) as [Serial No], Id, Rank, Designation, Salary from Employee where Rank<=2) as emp
  on e.Rank = emp.Rank