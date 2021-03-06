﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Api.Enums;
using VastGIS.Plugins.Services;
using VastGIS.RealEstate.Data.Entity;
using VastGIS.UI.Forms;

namespace VastGIS.Plugins.RealEstate.Forms
{
    public partial class frmSelectLayer : MapWindowForm
    {
        private GeometryType _geometryType;
        private List<VgObjectclasses> _selectedClass;
        private List<VgObjectclasses> _sourceClass;
        private List<VgObjectclasses> _listClass;
        public frmSelectLayer(List<VgObjectclasses> classes,GeometryType geometryType)
        {
            InitializeComponent();
            _geometryType = geometryType;
            if (geometryType != GeometryType.None)
            {
                _sourceClass = classes.Where(c => c.Txlx == (int)geometryType).ToList();
               
            }
            else
            {
                _sourceClass = classes;
               
            }
            _listClass=new List<VgObjectclasses>();
            _listClass.AddRange(_sourceClass);
            RefreshList();
            
            
            lstGroup.Items.Add("全部");
            lstGroup.Items.AddRange(_sourceClass.Select(c=>c.Fbmc).Distinct().ToArray());
        }

        private void RefreshList()
        {
            lstLayers.Items.Clear();
            foreach (VgObjectclasses objectclasses in _listClass)
            {
                lstLayers.Items.Add(objectclasses.Information);
            }
        }

        public List<VgObjectclasses> SelectedObjectClasses
        {
            get { return _selectedClass; }
        }

        public SelectionMode SelectionMode
        {
            get { return lstLayers.SelectionMode; }
            set
            {
                lstLayers.SelectionMode=value;
                btnSelectAll.Enabled = value == SelectionMode.MultiSimple || value == SelectionMode.MultiExtended;
                btnRevSelect.Enabled = value == SelectionMode.MultiSimple || value == SelectionMode.MultiExtended;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for(int i=0; i<lstLayers.Items.Count;i++)
            lstLayers.SetSelected(i,true);
        }

        private void btnRevSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLayers.Items.Count; i++)
                lstLayers.SetSelected(i, !lstLayers.GetSelected(i));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstLayers.SelectedItems.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _selectedClass = null;
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstLayers.SelectionMode == SelectionMode.One)
            {
                if (lstLayers.SelectedIndex < 0)
                {
                    MessageService.Current.Warn("请选择图层!");
                    return;
                }
                _selectedClass=new List<VgObjectclasses>();
                _selectedClass.Add((_listClass[lstLayers.SelectedIndex]));
                DialogResult = DialogResult.OK;
                return;
            }
            if (lstLayers.SelectedItems.Count<1)
            {
                MessageService.Current.Warn("请选择图层!");
                return;
            }
            _selectedClass = new List<VgObjectclasses>();
            foreach (var oneItem in lstLayers.SelectedIndices)
            {
                _selectedClass.Add(_listClass[(int)oneItem]);
            }
            DialogResult = DialogResult.OK;
        }

        private void lstGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lstGroup.SelectedIndex == 0)
            {
                _listClass.Clear();
                _listClass.AddRange(_sourceClass);
            }
            else
            {
                _listClass.Clear();
                string groupName = lstGroup.SelectedItem.ToString();
                foreach (var oneclass in _sourceClass)
                {
                    if(oneclass.Fbmc==groupName)
                        _listClass.Add(oneclass);
                }
                RefreshList();

            }
        }
    }
}
