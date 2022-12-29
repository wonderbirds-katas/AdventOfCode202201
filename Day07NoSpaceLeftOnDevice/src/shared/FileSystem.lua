local M = {}

local function CreateNode(name, parent)
	result = {}
	result.name = name
	result.parent = parent

	-- TODO error handling: parent must be a directory
	
	if parent ~= nil then
		table.insert(parent.children, result)
	end

	return result
end

function M.CreateDirectory(name, parent)
    result = CreateNode(name, parent)
	result.children = {}

	return result
end

function M.CreateFile(name, size, parent)
	result = CreateNode(name, parent)
	return result
end

function M.IsDir(node)
	return node.children ~= nil
end

function M.ToString(rootDirectory, indent)
	indent = indent or ""
    result = ""
	
	if not M.IsDir(rootDirectory) then
		typeString = " (file, size=1)"
		result = result .. indent .. rootDirectory.name .. typeString .. "\n"
		return result
	end

	typeString = " (dir)"
	result = result .. indent .. rootDirectory.name .. typeString .. "\n"

    if indent == "" then
        indent = "+-- "
    else
        indent = "    " .. indent
    end

	for _, directory in ipairs(rootDirectory.children) do
		result = result .. M.ToString(directory, indent)
	end

    return result
end

return M
