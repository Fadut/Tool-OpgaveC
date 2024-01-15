using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLib
{
    public class ToolsRepository
    {
        private readonly List<Tool> _tools = new();
        private int _nextId = 1;

        public ToolsRepository()
        {
            _tools.Add(new Tool() { Id = _nextId++, Type = "Saw", Price = 280 });
            _tools.Add(new Tool() { Id = _nextId++, Type = "Wrench", Price = 200 });
            _tools.Add(new Tool() { Id = _nextId++, Type = "Drill", Price = 700 });
            _tools.Add(new Tool() { Id = _nextId++, Type = "Hammer", Price = 130 });
        }

        public IEnumerable<Tool> GetAll()
        {
            IEnumerable<Tool> tools = new List<Tool>(_tools);
            return tools;
        }

        public Tool? GetById(int id)
        {
            return _tools.Find(tool =>  tool.Id == id);
        }

        public Tool Add(Tool tool)
        {
            tool.Validate();

            tool.Id = _nextId++;
            _tools.Add(tool);
            return tool;
        }

        public Tool? Update(int id, Tool tool)
        {
            if (tool == null)
            {
                return null;
            }

            tool.Validate();

            Tool? existingTool = GetById(id);
            if (existingTool == null)
            {
                return null;
            }

            existingTool.Type = tool.Type;
            existingTool.Price = tool.Price;

            return existingTool;
        }
    }
}
