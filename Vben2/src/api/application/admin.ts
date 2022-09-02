import { defHttp } from '/@/utils/http/axios';

enum Api {
  // 字典接口
  GetDictTypePageList = '/appDictType/page',
  GetDictTypeList = '/appDictType/list',
  AddDictType = '/appDictType/add',
  UpdateDictType = '/appDictType/update',
  DeleteDictType = '/appDictType/delete',

  GetDictDataPageList = '/appDictData/page',
  AddDictData = '/appDictData/add',
  UpdateDictData = '/appDictData/update',
  DeleteDictData = '/appDictData/delete',
  GetDictDataDropdown = '/appDictData/DictDataDropdown',
  QueryDictDataDropdown = '/appDictData/queryDictDataDropdown',
}

// 获取字典类型列表
export const getDictTypePageList = (params?: any) =>
  defHttp.get<any>({ url: Api.GetDictTypePageList, params });
export const getDictTypeList = (params?: any) =>
  defHttp.get<any>({ url: Api.GetDictTypeList, params });
// 增加典类型
export const addDictType = (params: any) => defHttp.post({ url: Api.AddDictType, params });
// 删除字典类型
export const deleteDictType = (id: number) =>
  defHttp.post({ url: Api.DeleteDictType, params: { id } });
// 更新字典类型
export const updateDictType = (params: any) => defHttp.post({ url: Api.UpdateDictType, params });

// 获取字典类型分页列表
export const getDictDataList = (params?: any) =>
  defHttp.get<any>({ url: Api.GetDictDataPageList, params });
// 从字典中值，下拉框控件使用
export const getDictDataDropdown = (params: any) =>
  defHttp.get<any>({ url: Api.GetDictDataDropdown + '/' + params });
// 根据条件，从字典中值，下拉框控件使用
export const queryDictDataDropdown = (params: any) =>
  defHttp.get<any>({ url: Api.QueryDictDataDropdown, params });
// 增加典类型
export const addDictData = (params: any) => defHttp.post({ url: Api.AddDictData, params });
// 删除字典类型
export const deleteDictData = (id: number) =>
  defHttp.post({ url: Api.DeleteDictData, params: { id } });
// 更新字典类型
export const updateDictData = (params: any) => defHttp.post({ url: Api.UpdateDictData, params });
